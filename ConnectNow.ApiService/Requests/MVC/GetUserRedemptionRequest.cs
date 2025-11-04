using Newtonsoft.Json;

namespace ConnectNow.ApiService.Requests.MVC
{
    public class GetUserRedemptionRequest
    {
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public int UserKey { get; }

        public GetUserRedemptionRequest(int userKey)
        {
            Authorization = Configuration.Authorization;
            UserKey = userKey;
        }
    }
}
