using Newtonsoft.Json;

namespace ConnectNow.ApiService.Requests.MVC
{
    public class RegisterByPhoneRequest
    {
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "APPID")]
        public string APPID { get; }

        [JsonProperty(PropertyName = "Phone")]
        public string Phone { get; }

        public RegisterByPhoneRequest(string phone)
        {
            Authorization = "123";
            APPID = "AAL_Mindy";
            Phone = phone;
        }
    }
}
