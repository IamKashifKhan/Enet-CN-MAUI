using Newtonsoft.Json;

namespace ConnectNow.ApiService.Requests.MVC
{
    public class BusinessDetailoffersRequest
    {
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "BusinessKey")]
        public string BusinessKey { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public int UserKey { get; }

        public BusinessDetailoffersRequest(int userkey, string businesskey)
        {
            Authorization = "123";
            BusinessKey = businesskey;
            UserKey = userkey;
        }
    }
}
