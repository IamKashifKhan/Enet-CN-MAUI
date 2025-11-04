// calendar.js (ES module)

function pad(n) { return n < 10 ? '0' + n : '' + n; }
function toKey(y, m, d) { return `${y}-${pad(m + 1)}-${pad(d)}`; }

function normalizeEvents(eventsArg) {
    // Accept either an array or a JSON string
    if (Array.isArray(eventsArg)) return eventsArg;
    if (typeof eventsArg === 'string') {
        try { return JSON.parse(eventsArg); } catch { /* fall through */ }
    }
    return [];
}

function toDateKeyLike(v) {
    if (!v) return null;
    if (v instanceof Date) return toKey(v.getFullYear(), v.getMonth(), v.getDate());
    // 'YYYY-MM-DD...' -> trim to 10
    return String(v).slice(0, 10);
}

function destroyOwl($el) {
    if ($el.hasClass('owl-loaded')) {
        $el.trigger('destroy.owl.carousel');
        $el.removeClass('owl-loaded');
        $el.html('');
    } else {
        $el.empty();
    }
}

function buildCalendarHtml(y, m, daysInMonth, eventSet, activeKey) {
    const dayNames = ['SUN', 'MON', 'TUE', 'WED', 'THU', 'FRI', 'SAT'];
    let html = '';
    for (let d = 1; d <= daysInMonth; d++) {
        const dateKey = toKey(y, m, d);
        const dayName = dayNames[new Date(y, m, d).getDay()];
        const isActive = dateKey === activeKey;
        const hasEvent = eventSet.has(dateKey);
        const classes = `item tabs${isActive ? ' active' : ''}${hasEvent ? ' event-dot' : ''}`;
        html += `
      <a href="#" data-date="${dateKey}" class="calendar-day">
        <div class="${classes}">
          <h6>${dayName} <span>${pad(d)}</span></h6>
        </div>
      </a>
    `;
    }
    return html;
}

/**
 * InitOwlCalendar
 * @param {string} containerSelector - e.g. "#owl-tabs"
 * @param {string} monthDateStr - "YYYY-MM-DD" (any day within the month to render)
 * @param {Array|string} eventsArg - ["YYYY-MM-DD", ...] or JSON string; objects with {date} also work
 * @param {string|null} activeDateStr - "YYYY-MM-DD" to preselect (defaults to today-if-in-month else 1st)
 * @param {string|null} navigateUrl - if provided, clicking navigates to `${navigateUrl}?date=YYYY-MM-DD`
 * @param {object|null} dotNetHelper - DotNetObjectReference from Blazor component; if provided, clicking calls `OnCalendarDaySelected(dateStr)`
 */
export function InitOwlCalendar(containerSelector, monthDateStr, eventsArg, activeDateStr, navigateUrl = null, dotNetHelper = null) {
    const $owlTabs = $(containerSelector);
    if (!$owlTabs.length) return;

    //destroyOwl($owlTabs);

    // Month math (avoid TZ drift by taking Y/M from a Date created from the string)
    const base = new Date(String(monthDateStr));
    if (isNaN(base)) throw new Error('InitOwlCalendar: invalid monthDateStr.');
    const y = base.getFullYear();
    const m = base.getMonth();
    const daysInMonth = new Date(y, m + 1, 0).getDate();
     // Active date (default: today if in month, otherwise 1st)
    const today = new Date();
    const todayKey = toKey(today.getFullYear(), today.getMonth(), today.getDate());
    const thisMonthPrefix = `${y}-${pad(m + 1)}-`;
    const normalizedActive = toDateKeyLike(activeDateStr);
    const defaultActive = todayKey.startsWith(thisMonthPrefix) ? todayKey : `${thisMonthPrefix}01`;
    const activeKey = (normalizedActive && normalizedActive.startsWith(thisMonthPrefix)) ? normalizedActive : defaultActive;

    // Events → Set('YYYY-MM-DD')
    const events = normalizeEvents(eventsArg);
    const eventSet = new Set(
        events.map(e => {
            if (typeof e === 'string') return e.slice(0, 10);
            if (e && e.date) return String(e.date).slice(0, 10);
            if (e && e.Date) return String(e.Date).slice(0, 10);
            return null;
        }).filter(Boolean)
    );

    // Build DOM
    $owlTabs.html(buildCalendarHtml(y, m, daysInMonth, eventSet, activeKey));
    // Init Owl
    const $owl = $owlTabs.owlCarousel({
        loop: false,
        nav: true,
        dots: false,
        margin: 8,
        stagePadding: 13,
        autoWidth: true,
        responsiveClass: true,
        onInitialized: () => setTimeout(() => {
            const $nonCloned = $owl.find('.owl-item:not(.cloned)');
            const $active = $nonCloned.find('.item.tabs.active').closest('.owl-item');
            const index = $nonCloned.index($active);
            if (index >= 0) $owl.trigger('to.owl.carousel', [index, 300, true]);
        }, 100)
    });

    // Click handler (single-bound)
    $owlTabs.off('click.calendar').on('click.calendar', 'a.calendar-day', function (e) {
        const $a = $(this);
        const dateStr = $a.data('date');

        // UI: active state
        $owlTabs.find('.item.tabs.active').removeClass('active');
        $a.find('.item.tabs').addClass('active');

        if (dotNetHelper && typeof dotNetHelper.invokeMethodAsync === 'function') {
            // Call back into your Blazor component instance method: OnCalendarDaySelected(string dateStr)
            e.preventDefault();
            dotNetHelper.invokeMethodAsync('OnCalendarDaySelected', dateStr);
            return;
        }

        if (navigateUrl) {
            // Let the browser navigate (GET)
            $a.attr('href', `${navigateUrl}?date=${dateStr}`);
            return; // no preventDefault -> follow link
        }

        // No .NET helper and no navigateUrl -> stay on page
        e.preventDefault();
        if (window.CalendarDaySelected) window.CalendarDaySelected(dateStr); // optional global

    });
}

/**
 * Optional helpers you can call from .NET too
 */

export function RebuildOwlForMonth(containerSelector, monthDateStr, eventsArg, activeDateStr, navigateUrl = null, dotNetHelper = null) {
    // Just re-run init (it destroys existing and rebuilds)
    InitOwlCalendar(containerSelector, monthDateStr, eventsArg, activeDateStr, navigateUrl, dotNetHelper);
}


// Moves the active highlight and scrolls to it, without rebuilding
export function SetOwlActiveDate(containerSelector, dateStr) {
    const $owlTabs = $(containerSelector);
    const $a = $owlTabs.find(`a.calendar-day[data-date="${dateStr}"]`);
    if (!$a.length) return;

    $owlTabs.find('.item.tabs.active').removeClass('active');
    $a.find('.item.tabs').addClass('active');

    // Scroll into view within Owl
    const $owl = $owlTabs;
    const $nonCloned = $owl.find('.owl-item:not(.cloned)');
    const $activeItem = $a.closest('.owl-item');
    const index = $nonCloned.index($activeItem);
    if (index >= 0) $owl.trigger('to.owl.carousel', [index, 300, true]);
}

// wwwroot/js/monthYearPicker.js  (ES module)

function debounce(fn, delay) {
    let t;
    return (...args) => { clearTimeout(t); t = setTimeout(() => fn(...args), delay); };
}

export function initMonthYearPicker(config = {}, dotNetHelper = null) {
    const cfg = {
        containerId: 'offcanvasMonYrPicker',
        monthListId: 'monthList',         // div id that contains <ul>
        yearListId: 'yearList',          // div id that contains <ul>
        previewId: 'selectedPreview',
        headerId: 'txt_monthYear',     // where to mirror final text
        liHeight: 44,
        buffer: 20,
        yearRange: 100,                  // ring size
        // optional: start centered on a specific month/year
        initialMonth: null,               // 1..12
        initialYear: null,               // e.g., 2025
        ...config
    };

    const $picker = $(`#${cfg.containerId}`);
    if (!$picker.length) return;

    // Elements
    const $monthCol = $(`#${cfg.monthListId}`);
    const $yearCol = $(`#${cfg.yearListId}`);
    const $preview = $(`#${cfg.previewId}`);
    const $monthUL = $monthCol.find('ul');
    const $yearUL = $yearCol.find('ul');

    // Namespacing to avoid duplicate handlers
    const NS = `.mypicker_${cfg.containerId}`;

    // Compute year ring start (center current year)
    const now = new Date();
    const currentYear = now.getFullYear();
    const yearStart = currentYear - Math.floor(cfg.yearRange / 2);

    // Data (months ring)
    const months = ["January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"];

    // Rebuild lists every init (idempotent)
    $monthUL.empty();
    for (let i = -cfg.buffer; i <= months.length + cfg.buffer; i++) {
        $('<li>').text(months[(i + 12) % 12]).appendTo($monthUL);
    }

    $yearUL.empty();
    for (let i = -cfg.buffer; i <= cfg.yearRange + cfg.buffer; i++) {
        $('<li>').text(yearStart + ((i + cfg.yearRange) % cfg.yearRange)).appendTo($yearUL);
    }

    // Helpers
    function getSelected($col, $list) {
        const idx = Math.round($col.scrollTop() / cfg.liHeight);
        const $li = $list.children().eq(idx);
        return { index: idx, text: $li.text(), el: $li };
    }
    function updateSelected($col, $list) {
        const { index } = getSelected($col, $list);
        $list.children().removeClass('selected');
        $list.children().eq(index).addClass('selected');
        $col.stop(true).animate({ scrollTop: index * cfg.liHeight }, 100);
    }
    function getMonth1To12() {
        // Read from visual selection (text) for robustness
        const mText = getSelected($monthCol, $monthUL).text;
        const idx0 = months.indexOf(mText);
        return idx0 >= 0 ? idx0 + 1 : (now.getMonth() + 1);
    }
    function getYear() {
        return parseInt(getSelected($yearCol, $yearUL).text, 10) || currentYear;
    }
    function updatePreviewAndNotify() {
        const m = getSelected($monthCol, $monthUL).text;
        const y = getSelected($yearCol, $yearUL).text;
        $preview.text(`${m} ${y}`);
        // Notify Blazor on selection change
        if (dotNetHelper && typeof dotNetHelper.invokeMethodAsync === 'function') {
            try { dotNetHelper.invokeMethodAsync('OnMonthYearChanged', getMonth1To12(), getYear()); } catch { /* noop */ }
        }
    }

    // Unbind previous handlers for this instance
    $monthCol.off(NS);
    $yearCol.off(NS);
    $(document).off(NS);
    $(`#${cfg.containerId}_savePicker`).off(NS); // in case used elsewhere

    // Scroll handlers (debounced)
    const onScroll = debounce(() => {
        updateSelected($monthCol, $monthUL);
        updateSelected($yearCol, $yearUL);
        updatePreviewAndNotify();
    }, 100);

    $monthCol.on(`scroll${NS}`, onScroll);
    $yearCol.on(`scroll${NS}`, onScroll);

    // Wheel (step one row at a time)
    function onWheelFactory($col) {
        return function (e) {
            e.preventDefault();
            const dir = e.originalEvent.deltaY > 0 ? 1 : -1;
            this.scrollBy({ top: dir * cfg.liHeight, behavior: 'smooth' });
        };
    }
    $monthCol.on(`wheel${NS}`, onWheelFactory($monthCol));
    $yearCol.on(`wheel${NS}`, onWheelFactory($yearCol));

    // Dragging
    function attachDrag($col) {
        $col.on(`mousedown${NS}`, function (e) {
            const startY = e.pageY, startScroll = $col.scrollTop();
            function move(ev) { $col.scrollTop(startScroll - (ev.pageY - startY)); }
            function up() {
                $(document).off(`mousemove${NS}`, move).off(`mouseup${NS}`, up);
                updateSelected($col, $col.find('ul'));
                updatePreviewAndNotify();
            }
            $(document).on(`mousemove${NS}`, move).on(`mouseup${NS}`, up);
        });
    }
    attachDrag($monthCol);
    attachDrag($yearCol);

    // Initial scroll positions
    const mInit = (cfg.initialMonth && cfg.initialMonth >= 1 && cfg.initialMonth <= 12)
        ? cfg.initialMonth - 1
        : now.getMonth();
    const yInit = (cfg.initialYear && Number.isInteger(cfg.initialYear))
        ? cfg.initialYear
        : currentYear;

    const initialMonthIndex = cfg.buffer + mInit;
    const initialYearIndex = cfg.buffer + (((yInit - yearStart) % cfg.yearRange + cfg.yearRange) % cfg.yearRange);

    $monthCol.scrollTop(initialMonthIndex * cfg.liHeight);
    $yearCol.scrollTop(initialYearIndex * cfg.liHeight);

    updateSelected($monthCol, $monthUL);
    updateSelected($yearCol, $yearUL);
    updatePreviewAndNotify();

    // Save button inside this offcanvas (optional helper id: containerId + "_savePicker")
    // If you use a shared #savePicker button, adjust selector below.
    const $saveBtn = $('#savePicker').length ? $('#savePicker') : $(`#${cfg.containerId}_savePicker`);
    $saveBtn.on(`click${NS}`, function () {
        // Mirror to header
        const text = $preview.text();
        if (cfg.headerId) $(`#${cfg.headerId}`).text(text);

        // Notify Blazor of final commit
        if (dotNetHelper && typeof dotNetHelper.invokeMethodAsync === 'function') {
            try { dotNetHelper.invokeMethodAsync('OnMonthYearSaved', getMonth1To12(), getYear()); } catch { /* noop */ }
        }

        // Close offcanvas
        const el = document.getElementById(cfg.containerId);
        window.bootstrap?.Offcanvas.getInstance(el)?.hide();
    });

    // Ensure preview refresh when shown
    const offEl = document.getElementById(cfg.containerId);
    if (offEl) {
        offEl.addEventListener('shown.bs.offcanvas', updatePreviewAndNotify);
    }
}

export function initToday(selector = '#today', dateInput = null) {
    const $today = $(selector);
    if (!$today.length) return;

    let d = null;
    if (dateInput instanceof Date) d = dateInput;
    else if (typeof dateInput === 'string') {
        const m = /^\s*(\d{4})-(\d{2})-(\d{2})/.exec(dateInput);
        d = m ? new Date(+m[1], +m[2] - 1, +m[3]) : (isNaN(new Date(dateInput)) ? null : new Date(dateInput));
    } else if (typeof dateInput === 'number') d = new Date(dateInput);

    if (!(d instanceof Date) || isNaN(d)) d = new Date();

    const dd = String(d.getDate()).padStart(2, '0');
    $today.text(dd);
}


export function GetOwlState(selector) {
    const $owl = $(selector);
    const $a = $owl.find('.item.tabs.active').closest('a.calendar-day');
    const date = $a.data('date') || null;

    const $nonCloned = $owl.find('.owl-item:not(.cloned)');
    const $activeItem = $a.closest('.owl-item');
    const index = Math.max(0, $nonCloned.index($activeItem));

    return { date, index };
}

export function RestoreOwlState(selector, state) {
    if (!state) return;
    const $owl = $(selector);
    const $a = $owl.find(`a.calendar-day[data-date="${state.date}"]`);
    if (!$a.length) return;

    $owl.find('.item.tabs.active').removeClass('active');
    $a.find('.item.tabs').addClass('active');

    const $nonCloned = $owl.find('.owl-item:not(.cloned)');
    const $activeItem = $a.closest('.owl-item');
    let index = $nonCloned.index($activeItem);
    if (index < 0) index = state.index || 0;

    // jump without animation
    $owl.trigger('to.owl.carousel', [index, 0, true]);
}
function scrollToActive($owl) {
    setTimeout(() => {
        const $nonCloned = $owl.find('.owl-item:not(.cloned)');
        const $active = $nonCloned.find('.item.tabs.active').closest('.owl-item');
        const index = $nonCloned.index($active);
        if (index >= 0) $owl.trigger('to.owl.carousel', [index, 300, true]);
    }, 0);
}

export function UpdateOwlForMonth(selector, monthDateStr, eventsArg, activeDateStr) {
    const $owl = $(selector);
    if (!$owl.length) return;

    // compute month parts
    const base = new Date(String(monthDateStr));
    if (isNaN(base)) return;
    const y = base.getFullYear();
    const m = base.getMonth();
    const daysInMonth = new Date(y, m + 1, 0).getDate();

    const today = new Date();
    const pad = (n) => (n < 10 ? '0' + n : '' + n);
    const toKey = (Y, M, D) => `${Y}-${pad(M + 1)}-${pad(D)}`;
    const thisMonthPrefix = `${y}-${pad(m + 1)}-`;
    const norm = (v) => (v ? String(v).slice(0, 10) : null);
    const activeKey = (norm(activeDateStr)?.startsWith(thisMonthPrefix))
        ? norm(activeDateStr)
        : (toKey(today.getFullYear(), today.getMonth(), today.getDate()).startsWith(thisMonthPrefix)
            ? toKey(today.getFullYear(), today.getMonth(), today.getDate())
            : `${thisMonthPrefix}01`);

    const evs = normalizeEvents(eventsArg);
    const eventSet = new Set(evs.map(e => typeof e === 'string'
        ? e.slice(0, 10)
        : (e?.date || e?.Date ? String(e.date ?? e.Date).slice(0, 10) : null)).filter(Boolean));

    const newHtml = buildCalendarHtml(y, m, daysInMonth, eventSet, activeKey);

    if ($owl.hasClass('owl-loaded')) {
        // Replace items in place (no teardown)
        $owl.trigger('replace.owl.carousel', [newHtml]);
        $owl.trigger('refresh.owl.carousel');
        scrollToActive($owl);
    } else {
        // First-time init fallback
        $owl.html(newHtml).owlCarousel({
            loop: false,
            nav: true,
            dots: false,
            margin: 8,
            stagePadding: 13,
            autoWidth: true,
            responsiveClass: true,
            onInitialized: () => scrollToActive($owl)
        });
    }
}


export function showOffcanvas(selector) {
    const el = document.querySelector(selector);
    if (!el) return;
    // Requires Bootstrap JS to be loaded on the page
    const instance = bootstrap.Offcanvas.getOrCreateInstance(el);
    instance.show();
}




export function showHideModal(showModal) {
    if (showModal) {
        $("#modalRedeemSuccess").modal("show");
    } else {
        $("#modalRedeemSuccess").modal("hide");
    }
}


// Ensure this file is loaded after jQuery + owl.carousel.js
export function owlCarouselstart() {
    const $owl = $("#owl-tabs-offers");
    if (!$owl.length) return;

    if (!$.fn || !$.fn.owlCarousel) {
        console.error("Owl Carousel is not loaded.");
        return;
    }

    const opts = {
        loop: false,
        nav: false,
        dots: false,
        margin: 10,
        stagePadding: 13,
        autoWidth: true,
        responsiveClass: true
    };

    // If already initialized, try refresh; fallback to full re-init
    const isInitialized = $owl.hasClass("owl-loaded") || !!$owl.data("owl.carousel");

    if (isInitialized) {
        try {
            // Fast path: re-calc sizes/positions
            $owl.trigger("refresh.owl.carousel");
        } catch {
            // Fallback: destroy and reinitialize
            safeReinit($owl, opts);
        }
    } else {
        $owl.owlCarousel(opts);
    }
}

function safeReinit($owl, opts) {
    try {
        $owl.trigger("destroy.owl.carousel");
    } catch { /* ignore */ }

    // Clean up DOM that Owl wraps around items
    $owl.removeClass("owl-loaded owl-hidden");
    $owl.find(".owl-stage-outer").children().unwrap(); // unwrap stage
    // (If .owl-nav/.owl-dots exist, you can remove them too)
    $owl.find(".owl-nav, .owl-dots").remove();

    // Re-init
    $owl.owlCarousel(opts);
}


// mapOffersCarousel.js
// Requires jQuery + Owl Carousel 2 to be loaded globally.
// Import in Blazor and call: initOffersCarousel(), bindOffersRange(), updateOffersCarousel().

let $el = null;
let dotnet = null;
let updateToken = 0;

export function initOffersCarousel(selector, dotnetRef, owlOptions = {}) {
    dotnet = dotnetRef;
    const jq = window.jQuery;
    if (!jq) { console.error('jQuery not found'); return; }

    $el = jq(selector);
    if (!$el || $el.length === 0) return;

    // Avoid double init on same element
    if ($el.data('mapoffers-initialized')) return;

    const defaults = {
        autoWidth: true,
        items: 4,
        margin: 10,
        nav: true,
        dots: false,
        smartSpeed: 250,
        loop: false,
        mouseDrag: true,
        pullDrag: true,
        responsive: {
            0: { items: 1 },
            576: { items: 2 },
            992: { items: 3 },
            1200: { items: 4 }
        }
    };

    $el.owlCarousel(Object.assign({}, defaults, owlOptions));
    $el.data('mapoffers-initialized', true);

    // Delegated, namespaced handlers (won't clash with .calendar handlers)
    $el.off('.mapoffers');
    $el.on('click.mapoffers', '.card-redeem .btn', function (ev) {
        ev.preventDefault(); ev.stopPropagation();
        const card = this.closest('a.card');
        if (card && card.__offer && dotnet) {
            dotnet.invokeMethodAsync('OnOfferRedeem', card.__offer);
        }
    });

    $el.on('click.mapoffers', 'a.card', function (ev) {
        ev.preventDefault();
        if (this.__offer && dotnet) {
            dotnet.invokeMethodAsync('OnOfferSelected', this.__offer);
        }
    });
}

export function updateOffersCarousel(offers, hasActivePlan) {
    if (!$el || $el.length === 0) return;
    const token = ++updateToken;

    // Remember index (prevents jumps during refresh)
    let currentIndex = 0;
    try {
        const api = $el.data('owl.carousel');
        if (api) currentIndex = api.current();
    } catch { }

    // Build nodes
    const nodes = [];
    for (const o of (offers || [])) nodes.push(createOfferCardNode(o, hasActivePlan));

    // Replace + refresh, then restore position
    $el.trigger('replace.owl.carousel', [window.jQuery(nodes)])
        .trigger('refresh.owl.carousel');

    requestAnimationFrame(() => {
        if (token !== updateToken) return;
        $el.trigger('to.owl.carousel', [currentIndex, 0, true]);
    });
}

export function bindOffersRange(rangeSelector, debounceMs = 200) {
    const input = document.querySelector(rangeSelector);
    if (!input) return;

    input.addEventListener('input', debounceMapOffers(async () => {
        const radius = Number(input.value);
        if (dotnet && Number.isFinite(radius)) {
            const offers = await dotnet.invokeMethodAsync('GetOffersForRadius', radius);
            updateOffersCarousel(offers || []);
            if (dotnet) dotnet.invokeMethodAsync('OnRangeResultCount', (offers || []).length);
        }
    }, debounceMs));
}

export function destroyOffersCarousel() {
    if ($el && $el.hasClass('owl-loaded')) $el.trigger('destroy.owl.carousel');
    if ($el) $el.off('.mapoffers').removeData('mapoffers-initialized');
    $el = null; dotnet = null; updateToken = 0;
}

/* ---------- helpers ---------- */

// Helper: read PascalCase OR camelCase (and coerce numbers)
function getProp(o, name) {
    if (!o) return undefined;
    if (name in o) return o[name];
    const camel = name[0].toLowerCase() + name.slice(1);
    if (camel in o) return o[camel];
    return undefined;
}

function createOfferCardNode(o, hasActivePlan) {
    const heading = getProp(o, 'Heading') ?? '';
    const businessName = getProp(o, 'BusinessName') ?? '';
    const logoPath = getProp(o, 'BusinessLogoPath') ?? '';
    const thumbPath =
        getProp(o, 'ThumbnailPath')
        || getProp(o, 'ImagePath')
        || getProp(o, 'BusinessProfileImagePath')
        || getProp(o, 'CodeImage_ThumbnailPath')
        || '';
    const redemptions = Number(getProp(o, 'RedemptionsCount')) || 0;
    const views = Number(getProp(o, 'OfferViews')) || 0;
    const businessKey = getProp(o, 'BusinessKey');

    // Wrapper: <div class="card"> (plus .blur when not active)
    const wrapper = document.createElement('div');
    wrapper.className = 'card' + (hasActivePlan ? '' : ' blur');

    // Locked/upgrade banner when no active plan
    if (!hasActivePlan) {
        const lock = document.createElement('div');
        lock.className = 'member-only';
        lock.innerHTML = `
            To view and redeem this offer, please upgrade your account...
            <button class="btn btn-secondary btn-sm d-flex mx-auto mt-1">
                <img src="img/lock.svg" class="me-1" alt="" /> Start Saving
            </button>
        `;
        wrapper.appendChild(lock);
    }

    // Anchor (note: when active, anchor has class="card" per your sample)
    const a = document.createElement('a');
    a.href = '#';
    if (hasActivePlan) a.className = 'card';
    if (businessKey != null) a.dataset.bkey = String(businessKey);
    a.__offer = o;

    // Left content
    const left = document.createElement('div');
    const h6Title = document.createElement('h6');
    h6Title.className = 'card-title text-truncate';
    h6Title.textContent = heading;

    const bus = document.createElement('div');
    bus.className = 'bus-title';
    if (logoPath) {
        const img = new Image();
        img.src = logoPath;
        img.alt = '';
        bus.appendChild(img);
    }
    const h6Biz = document.createElement('h6');
    h6Biz.className = 'bus-label text-truncate';
    h6Biz.textContent = businessName;
    bus.appendChild(h6Biz);

    left.appendChild(h6Title);
    left.appendChild(bus);

    // Center image
    const center = document.createElement('div');
    center.className = 'card-img';
    if (thumbPath) center.style.backgroundImage = `url("${thumbPath}")`;

    // Right actions
    const right = document.createElement('div');
    right.className = 'card-redeem';
    right.innerHTML = `
        <button class="btn btn-primary btn-sm me-auto">Redeem</button>
        <span title="Redemptions"><i class="bi bi-ticket-detailed"></i> ${redemptions}</span>
        <span title="Views"><i class="bi bi-eye"></i> ${views}</span>
    `;

    // Assemble
    a.appendChild(left);
    a.appendChild(center);
    a.appendChild(right);
    wrapper.appendChild(a);

    return wrapper;
}

function debounceMapOffers(fn, wait = 150) {
    let t;
    return (...args) => { clearTimeout(t); t = setTimeout(() => fn.apply(null, args), wait); };
}
