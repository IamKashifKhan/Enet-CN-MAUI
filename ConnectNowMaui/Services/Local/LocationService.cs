// Services/LocationService.cs
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices.Sensors;
using ConnectNow.Services.Local;
using Location = Microsoft.Maui.Devices.Sensors.Location;



#if ANDROID
using Android.Content;
using Android.Locations;
using Android.Provider;
#endif

#if IOS
using CoreLocation;
#endif

namespace ConnectNow.Services.Local;

public sealed class LocationService : ILocationService
{
    public async Task<Location?> GetCurrentLocationAsync(
        GeolocationAccuracy accuracy = GeolocationAccuracy.Medium,
        int timeoutSeconds = 10,
        bool useLastKnownFallback = true,
        CancellationToken cancellationToken = default)
    {
        // 0) Make sure device services (GPS/Location) are ON
        if (!AreLocationServicesEnabled())
        {
            // optional: send user to settings
            try { AppInfo.ShowSettingsUI(); } catch { /* no-op */ }
            return useLastKnownFallback ? await Geolocation.GetLastKnownLocationAsync() : null;
        }

        // 1) Ensure permission
        var hasPermission = await EnsurePermissionAsync();
        if (!hasPermission)
            return useLastKnownFallback ? await Geolocation.GetLastKnownLocationAsync() : null;

        // 2) iOS only: if high accuracy requested, try to elevate from Reduced → Full
#if IOS
        if (accuracy == GeolocationAccuracy.High || accuracy == GeolocationAccuracy.Best)
        {
            await TryRequestTemporaryFullAccuracyAsync();
        }
#endif

        //// 3) Optional quick win: last known first
        //if (useLastKnownFallback)
        //{
        //    var last = await Geolocation.GetLastKnownLocationAsync();
        //    if (last is not null)
        //        return last;
        //}

        // 4) Fresh location
        try
        {
            var request = new GeolocationRequest(accuracy, TimeSpan.FromSeconds(timeoutSeconds));
            var current = await Geolocation.GetLocationAsync(request, cancellationToken);

            return current ?? (useLastKnownFallback ? await Geolocation.GetLastKnownLocationAsync() : null);
        }
        catch (OperationCanceledException) { return null; }
        catch (FeatureNotSupportedException) { return useLastKnownFallback ? await Geolocation.GetLastKnownLocationAsync() : null; }
        catch (FeatureNotEnabledException) { return useLastKnownFallback ? await Geolocation.GetLastKnownLocationAsync() : null; }
        catch (PermissionException) { return useLastKnownFallback ? await Geolocation.GetLastKnownLocationAsync() : null; }
        catch { return null; }
    }

    private static async Task<bool> EnsurePermissionAsync()
    {
        var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
        if (status != PermissionStatus.Granted)
            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        return status == PermissionStatus.Granted;
    }


    public bool IsOfferInRange(Location? offerLocation, Location? centerLocation, double radiusMeters)
    {
        if (offerLocation == null || centerLocation == null)
            return false;

       

        // Directly compute in meters
        double distanceMeters = Location.CalculateDistance(
            offerLocation,
            centerLocation,
            DistanceUnits.Kilometers)*1000;

        return distanceMeters <= radiusMeters;
    }

    //public static class LocationExtensions
    //{
    //    public static bool IsValid(this Location loc) =>
    //        loc != null &&
    //        !double.IsNaN(loc.Latitude) &&
    //        !double.IsNaN(loc.Longitude);
    //}

    private static bool AreLocationServicesEnabled()
    {
#if ANDROID
        try
        {
            var context = Android.App.Application.Context;
            var lm = (LocationManager?)context.GetSystemService(Context.LocationService);
            if (lm is null) return false;

            // Either GPS or Network provider being enabled is fine
            bool gps = lm.IsProviderEnabled(LocationManager.GpsProvider);
            bool net = lm.IsProviderEnabled(LocationManager.NetworkProvider);
            return gps || net;
        }
        catch { return false; }
#elif IOS
        return CLLocationManager.LocationServicesEnabled;
#else
        // Other platforms (Windows/MacCatalyst): assume enabled
        return true;
#endif
    }

#if IOS
    /// <summary>
    /// iOS 14+: If user granted only Reduced Accuracy, attempt temporary full accuracy
    /// (requires Info.plist NSLocationTemporaryUsageDescriptionDictionary with a purpose key).
    /// </summary>
    private static async Task TryRequestTemporaryFullAccuracyAsync()
    {
        try
        {
            using var manager = new CLLocationManager();
            if (CLLocationManager.LocationServicesEnabled)
            {
                if (manager.AccuracyAuthorization == CLAccuracyAuthorization.ReducedAccuracy)
                {
                    // The string must match a key in Info.plist's NSLocationTemporaryUsageDescriptionDictionary
                    // e.g., "PreciseNav" → { "PreciseNav" : "We need precise location to show nearby offers on the map." }
                    await manager.RequestTemporaryFullAccuracyAuthorizationAsync("PreciseNav");
                }
            }
        }
        catch
        {
            // Ignore if not supported / key missing
        }
    }
#endif
}
