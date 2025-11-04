using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.ApiService.Requests.MVC
{
    public class ReferralRequest
    {
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "APPID")]
        public string APPID { get; }

        [JsonProperty(PropertyName = "OfferCode")]
        public string OfferCode { get; }

        [JsonProperty(PropertyName = "Referral")]
        public string Referral { get; }

        public ReferralRequest(string offerCode, string referral)
        {
            Authorization = Configuration.Authorization;
            APPID = Configuration.AppId;
            OfferCode = offerCode;
            Referral = referral;
        }
    }
}
