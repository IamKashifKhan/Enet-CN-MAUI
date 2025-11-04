using Newtonsoft.Json;

namespace ConnectNow.ApiService.Requests.MVC
{
    public class VerifyByPhoneRequest
    {
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "APPID")]
        public string APPID { get; }

        [JsonProperty(PropertyName = "Phone")]
        public string Phone { get; }

        [JsonProperty(PropertyName = "VerificationCode")]
        public string VerificationCode { get; }

        public VerifyByPhoneRequest(string phone, string verificationCode)
        {
            Authorization = "123";
            APPID = "AAL_Mindy";
            Phone = phone;
            VerificationCode = verificationCode;
        }
    }
}
