using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.ApiService.Requests.MVC
{
    public class UserSubscriptionTransactionOfferRequest
    {
        // [AliasAs("email")]
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "APPID")]
        public string APPID { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }

        [JsonProperty(PropertyName = "OfferCode")]
        public string OfferCode { get; }

        public UserSubscriptionTransactionOfferRequest(string userkey, string offercode)
        {
            Authorization = Configuration.Authorization;
            APPID = "AAL_Mindy";
            UserKey = userkey;
            OfferCode = offercode;
        }
    }

}
