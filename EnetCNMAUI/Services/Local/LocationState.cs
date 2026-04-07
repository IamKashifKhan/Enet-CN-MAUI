namespace EnetCNMAUI.Services.Local
{
    public class LocationState : ILocationState
    {
        public Location? CurrentPosition { get; set; }
        public Location DefaultPosition => new() { Latitude = 34.27851, Longitude = -119.16 };
    }
}
