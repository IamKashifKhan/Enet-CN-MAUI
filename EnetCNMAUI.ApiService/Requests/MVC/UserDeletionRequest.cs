using Newtonsoft.Json;

namespace EnetCNMAUI.ApiService.Requests.MVC
{
    public class UserDeletionRequest
    {
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public int UserKey { get; }

        public UserDeletionRequest(int userKey)
        {
            Authorization = Configuration.Authorization;
            UserKey = userKey;
        }
    }
}
