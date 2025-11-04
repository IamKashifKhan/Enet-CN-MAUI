using Newtonsoft.Json;

namespace ConnectNow.ApiService.Requests.MVC
{
    public class EventRequest
    {
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "APPID")]
        public string APPID { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }

        public EventRequest(string userkey)
        {
            Authorization = Configuration.Authorization;
            APPID = "AAL_Mindy";
            UserKey = userkey;
        }
    }
}
