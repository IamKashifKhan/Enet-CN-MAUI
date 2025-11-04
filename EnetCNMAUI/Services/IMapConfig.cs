using Microsoft.Extensions.Configuration;
using Microsoft.Maui.Devices;

namespace EnetCNMAUI.Services;

public interface IMapConfig
{
    string GoogleMapsApiKey { get; }
}

public class MapConfig : IMapConfig
{
    public string GoogleMapsApiKey { get; }

    public MapConfig(IConfiguration configuration)
    {
        var googleMapsConfig = configuration.GetSection("GoogleMaps");
        GoogleMapsApiKey = DeviceInfo.Platform == DevicePlatform.iOS
            ? googleMapsConfig["iOSApiKey"]
            : googleMapsConfig["AndroidApiKey"];
    }
}