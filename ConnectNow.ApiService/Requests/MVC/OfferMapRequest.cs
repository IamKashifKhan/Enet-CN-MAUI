using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectNow.Helpers;

namespace ConnectNow.ApiService.Requests.MVC
{
    public class OfferMapRequest
    {
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "APPID")]
        public string APPID { get; }

        [JsonProperty(PropertyName = "Latitude")]
        public string Latitude { get; }

        [JsonProperty(PropertyName = "Longitude")]
        public string Longitude { get; }

        [JsonProperty(PropertyName = "Radius")]
        public string Radius { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }
        public object StringConstants { get; }

        public OfferMapRequest(string latitude, string longitude, string radius, string userKey)
        {
            Authorization = Configuration.Authorization;
            APPID = Configuration.AppId;
            Latitude = latitude;
            Longitude = longitude;
            Radius = radius;
            UserKey = userKey;
        }
    }
}
