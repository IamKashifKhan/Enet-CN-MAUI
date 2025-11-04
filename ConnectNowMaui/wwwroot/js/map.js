(function () {
    const FIT_PADDING = { top: 0, right: 0, bottom: 0, left: 0 };

    const state = {
        loaded: false,
        loadingPromise: null,
        map: null,
        markers: [],
        dotnetRef: null,
        circle: null,
        fixedRadiusMeters: 0,
        fixedCenter: null,
    };

    /**
     * Loads Google Maps JS API once only.
     * Reuses existing <script> or global google.maps if already loaded.
     */
    function ensureGeometryLoaded(key) {
        // 1. Already loaded?
        if (state.loaded && window.google && window.google.maps) {
            return Promise.resolve();
        }

        // 2. Already loading?
        if (state.loadingPromise) return state.loadingPromise;

        // 3. Check if script tag already exists
        const existing = document.querySelector(
            'script[src*="maps.googleapis.com/maps/api/js"]'
        );
        if (existing) {
            // Attach to onload if not yet resolved
            state.loadingPromise = new Promise((resolve, reject) => {
                if (window.google && window.google.maps) {
                    state.loaded = true;
                    resolve();
                } else {
                    existing.addEventListener("load", () => {
                        state.loaded = true;
                        resolve();
                    });
                    existing.addEventListener("error", (e) => reject(e));
                }
            });
            return state.loadingPromise;
        }

        // 4. Inject script only once
        state.loadingPromise = new Promise((resolve, reject) => {
            const url = `https://maps.googleapis.com/maps/api/js?key=${key}&libraries=geometry&callback=__gmapsLoaded`;
            const script = document.createElement("script");
            script.id = "google-maps-script";
            script.src = url;
            script.async = true;
            script.defer = true;

            script.onerror = (error) => {
                console.error("Google Maps JavaScript API error:", error);
                reject(
                    new Error(
                        "Failed to load Google Maps API. Please check your API key and network connection."
                    )
                );
            };

            // Global callback resolves our promise
            window.__gmapsLoaded = () => {
                state.loaded = true;
                resolve();
            };

            document.head.appendChild(script);
        });

        return state.loadingPromise;
    }

    async function ensureMarkerLib() {
        if (!google.maps.importLibrary) return null;
        if (!window.__markerLibLoaded) {
            window.__markerLibLoaded = await google.maps.importLibrary("marker");
        }
        return window.__markerLibLoaded;
    }

    function createCircleIfNeeded() {
        if (!state.map) return;
        if (state.circle) return;

        state.circle = new google.maps.Circle({
            map: state.map,
            center: state.fixedCenter || state.map.getCenter(),
            radius: 0,
            clickable: false,
            draggable: false,
            editable: false,
            strokeColor: "#2962FF",
            strokeOpacity: 0.9,
            strokeWeight: 2,
            fillColor: "#2962FF",
            fillOpacity: 0.15,
        });
    }

    window.gmapsInterop = {
        async load(apiKey) {
            return ensureGeometryLoaded(apiKey);
        },

        initMap(domId, center, zoom, dotnetRef) {
            const el = document.getElementById(domId);
            if (!el) return;

            state.map = new google.maps.Map(el, {
                center: { lat: center.lat, lng: center.lng },
                zoom: zoom ?? 12,
                disableDefaultUI: true,
                clickableIcons: false,
                gestureHandling: "greedy",
            });

            state.dotnetRef = dotnetRef || null;
            state.fixedCenter = { lat: center.lat, lng: center.lng };

            state.map.addListener("idle", () => {
                if (!state.dotnetRef) return;
                const center = state.map.getCenter();
                const zoom = state.map.getZoom();
                const bounds = state.map.getBounds();

                const payload = {
                    centerLat: center?.lat() ?? 0,
                    centerLng: center?.lng() ?? 0,
                    zoom: zoom ?? 0,
                    bounds: {
                        north: bounds?.getNorthEast().lat() ?? 0,
                        east: bounds?.getNorthEast().lng() ?? 0,
                        south: bounds?.getSouthWest().lat() ?? 0,
                        west: bounds?.getSouthWest().lng() ?? 0,
                    },
                    radiusMeters: 0,
                };

                payload.radiusMeters =
                    state.fixedRadiusMeters > 0
                        ? state.fixedRadiusMeters
                        : computeViewportRadiusMeters();

                updateAutoCircle();
                state.dotnetRef.invokeMethodAsync("OnMapViewChanged", payload);
            });
        },

        addMarker(lat, lng, business_key, title, optionsOrUrl) {
            if (!state.map) return;

            const opts =
                typeof optionsOrUrl === "string"
                    ? { url: optionsOrUrl }
                    : optionsOrUrl || {};

            const n = Number(optionsOrUrl ?? 0);
            const labelText = n === 1 ? "offer" : "offers";

            const markerOptions = {
                position: { lat, lng },
                map: state.map,
                title: title || "",
                zIndex: opts.zIndex ?? undefined,
                label: opts.label ?? undefined,
                clickable: opts.clickable ?? true,
                draggable: opts.draggable ?? false,
            };

            const infowindow = new google.maps.InfoWindow({
                content: `
                    <div class="">
                        <h6 class="text-truncate">${title}</h6>
                        <span class="card-offer">${optionsOrUrl} ${labelText}</span>
                    </div>`,
            });

            const marker = new google.maps.Marker(markerOptions);

            marker.addListener("click", () => {
                if (state.openInfoWindow) state.openInfoWindow.close();
                infowindow.open({
                    anchor: marker,
                    map: state.map,
                    shouldFocus: false,
                });
                state.openInfoWindow = infowindow;
                try {
                    state.dotnetRef.invokeMethodAsync("OnPinClick", business_key);
                } catch { }
            });

            state.markers.push(marker);
            return marker;
        },

        clearMarkers() {
            if (!state.markers || state.markers.length === 0) return;
            for (const m of state.markers) m?.setMap(null);
            state.markers.length = 0;
        },

        fitToMarkers() {
            if (!state.map || state.markers.length === 0) return;
            const b = new google.maps.LatLngBounds();
            state.markers.forEach((m) => b.extend(m.getPosition()));
            state.map.fitBounds(b, 60);
        },

        setCenter(lat, lng) {
            if (!state.map) return;
            state.map.setCenter({ lat, lng });
        },

        setZoom(zoom) {
            if (!state.map) return;
            state.map.setZoom(zoom);
        },

        setFixedCenter(lat, lng) {
            state.fixedCenter = { lat, lng };
            createCircleIfNeeded();
            if (state.circle) state.circle.setCenter(state.fixedCenter);
        },

        setRadiusMeters(meters) {
            state.fixedRadiusMeters = Number(meters) || 0;
            if (!state.map || !state.circle) return;

            if (state.fixedCenter) state.circle.setCenter(state.fixedCenter);

            if (state.fixedRadiusMeters > 0) {
                state.circle.setRadius(state.fixedRadiusMeters);
                state.circle.setVisible(true);

                if (state.fixedCenter) state.map.setCenter(state.fixedCenter);

                const bounds = state.circle.getBounds?.();
                if (bounds) {
                    state.map.fitBounds(bounds, FIT_PADDING);
                } else {
                    const lat =
                        state.fixedCenter?.lat ?? state.map.getCenter().lat();
                    const zoom = computeZoomForRadius(
                        lat,
                        state.fixedRadiusMeters,
                        state.map.getDiv().offsetWidth,
                        FIT_PADDING
                    );
                    if (Number.isFinite(zoom)) state.map.setZoom(zoom);
                }
            } else {
                updateAutoCircle();
            }
        },

        hideCircle() {
            if (state.circle) state.circle.setVisible(false);
        },
        showCircle() {
            if (state.circle) state.circle.setVisible(true);
        },
        removeCircle() {
            if (state.circle) {
                state.circle.setMap(null);
                state.circle = null;
            }
            state.fixedRadiusMeters = 0;
        },
    };

    // ---------- helpers ----------
    function computeViewportRadiusMeters() {
        if (!state.map) return 0;
        const bounds = state.map.getBounds();
        if (!bounds) return 0;

        const ne = bounds.getNorthEast();
        const sw = bounds.getSouthWest();

        const north = new google.maps.LatLng(ne.lat(), sw.lng());
        const south = new google.maps.LatLng(sw.lat(), sw.lng());
        const east = new google.maps.LatLng(sw.lat(), ne.lng());

        const height = google.maps.geometry.spherical.computeDistanceBetween(north, south);
        const width = google.maps.geometry.spherical.computeDistanceBetween(south, east);

        return Math.max(0, Math.min(height, width) / 2);
    }

    function updateAutoCircle() {
        if (!state.map || !state.circle) return;
        if (state.fixedCenter) state.circle.setCenter(state.fixedCenter);
        if (state.fixedRadiusMeters > 0) {
            state.circle.setRadius(state.fixedRadiusMeters);
            state.circle.setVisible(true);
        } else {
            const autoR = computeViewportRadiusMeters();
            state.circle.setRadius(autoR);
            state.circle.setVisible(autoR > 0);
        }
    }

    function computeZoomForRadius(centerLat, radiusMeters, mapWidthPx, padding) {
        const padH = (padding?.left ?? 0) + (padding?.right ?? 0);
        const availableWidth = Math.max(1, mapWidthPx - padH);
        const targetMetersAcross = Math.max(1, radiusMeters * 2);
        const mPerPxAtZoom0 = 156543.03392 * Math.cos((centerLat * Math.PI) / 180);
        const zoom = Math.log2((mPerPxAtZoom0 * availableWidth) / targetMetersAcross);
        return Math.max(2, Math.min(21, zoom));
    }
})();
