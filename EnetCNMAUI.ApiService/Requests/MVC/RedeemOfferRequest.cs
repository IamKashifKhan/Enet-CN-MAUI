using Newtonsoft.Json;

namespace EnetCNMAUI.ApiService.Requests.MVC
{
    public class RedeemOfferRequest
    {
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }

        [JsonProperty(PropertyName = "BusinessOffersKey")]
        public string BusinessOffersKey { get; }

        [JsonProperty(PropertyName = "RedemptionCode")]
        public string RedemptionCode { get; }

        public RedeemOfferRequest(string userKey, string businessOffersKey, string redemptionCode)
        {
            Authorization = Configuration.Authorization;
            UserKey = userKey;
            BusinessOffersKey = businessOffersKey;
            RedemptionCode = redemptionCode;
        }
    }
}
