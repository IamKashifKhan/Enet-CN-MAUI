using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnetCNMAUI.ApiService.Requests.MVC
{
    public class GetPlanRequest
    {
        // [AliasAs("email")]
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }


        [JsonProperty(PropertyName = "APPID")]
        public string APPID { get; }

        [JsonProperty(PropertyName = "PromoCode")]
        public string PromoCode { get; }

        [JsonProperty(PropertyName = "UserSubscriptionPlanKey")]
        public string UserSubscriptionPlanKey { get; }




        public GetPlanRequest(string promocode, string userSubscriptionPlanKey)
        {
            Authorization = Configuration.Authorization;
            APPID = "AAL_Mindy";
            PromoCode = promocode;
            UserSubscriptionPlanKey = userSubscriptionPlanKey;
        }
    }
}
