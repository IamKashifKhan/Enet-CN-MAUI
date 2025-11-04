using Newtonsoft.Json;

namespace EnetCNMAUI.ApiService.Requests.MVC
{
    public class BusinessScheduleRequest
    {
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "BusinessKey")]
        public string BusinessKey { get; }

        public BusinessScheduleRequest(string businesskey)
        {
            Authorization = "123";
            BusinessKey = businesskey;
        }
    }
}
