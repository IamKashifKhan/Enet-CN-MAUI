using Newtonsoft.Json;

namespace ConnectNow.ApiService.Requests.MVC
{
    public class AddOfferViewRequest
    {
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "BusinessKey")]
        public string BusinessOffersKey { get; }

        public AddOfferViewRequest(string businessofferkey)
        {
            Authorization = "123";
            BusinessOffersKey = businessofferkey;
        }
    }
}
