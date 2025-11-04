using Newtonsoft.Json;

namespace EnetCNMAUI.ApiService.Requests.MVC
{
    public class SetUserPasswordRequest
    {
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public int UserKey { get; }

        [JsonProperty(PropertyName = "Password")]
        public string Password { get; }

        [JsonProperty(PropertyName = "ConfirmPassword")]
        public string ConfirmPassword { get; }

        public SetUserPasswordRequest(int userkey, string password)
        {
            Authorization = "123";
            UserKey = userkey;
            Password = password;
            ConfirmPassword = password;
        }
    }
}
