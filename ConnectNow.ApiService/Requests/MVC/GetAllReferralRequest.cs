using Newtonsoft.Json;

namespace ConnectNow.ApiService.Requests.MVC
{
    public class GetAllReferralRequest
    {
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "APPID")]
        public string APPID { get; }

        public GetAllReferralRequest()
        {
            Authorization = Configuration.Authorization;
            APPID = Configuration.AppId;
        }
    }
}