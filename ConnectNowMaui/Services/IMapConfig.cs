using Microsoft.Maui.Devices;

namespace ConnectNow.Services;

public interface IMapConfig
{
    string GoogleMapsApiKey { get; }
}

public class MapConfig : IMapConfig
{
    public string GoogleMapsApiKey { get; set; } = string.Empty;
}