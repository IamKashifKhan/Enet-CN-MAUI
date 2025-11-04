// Services/LocationService.cs

namespace ConnectNow.Services.Local 
{ 
    public interface ILocationService
    {
        bool IsOfferInRange(Location point1, Location point2, double raidus);

        Task<Location?> GetCurrentLocationAsync(GeolocationAccuracy accuracy = GeolocationAccuracy.Medium, int timeoutSeconds = 10, bool useLastKnownFallback = true, CancellationToken cancellationToken = default);
    }
}