using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.ApiService.Requests.MVC
{
    public class SubscriptionTransactionRequest
    {

        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "APPID")]
        public string APPID { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }

        [JsonProperty(PropertyName = "UserSubscriptionPlanKey")]
        public string UserSubscriptionPlanKey { get; }

        [JsonProperty(PropertyName = "CC_Name")]
        public string CC_Name { get; }

        [JsonProperty(PropertyName = "CC_Number")]
        public string CC_Number { get; }

        [JsonProperty(PropertyName = "CC_EXP_MM")]
        public string CC_EXP_MM { get; }

        [JsonProperty(PropertyName = "CC_EXP_YYYY")]
        public string CC_EXP_YYYY { get; }

        [JsonProperty(PropertyName = "CC_CODE")]
        public string CC_CODE { get; }

        [JsonProperty(PropertyName = "Zipcode")]
        public string Zipcode { get; }

        [JsonProperty(PropertyName = "PromoCode")]
        public string PromoCode { get; }


        public SubscriptionTransactionRequest(string userkey, string usersubscriptionplankey, string ccname, string ccnumber, string ccexpmnth, string ccexpyr, string cccode, string zipcode , string DiscountCode)
        {
            Authorization = Configuration.Authorization;
            UserKey = userkey;
            CC_Name = ccname;
            CC_Number = ccnumber;
            CC_EXP_MM = ccexpmnth;
            CC_EXP_YYYY = ccexpyr;
            CC_CODE = cccode;
            Zipcode = zipcode;
            UserSubscriptionPlanKey = usersubscriptionplankey;
            APPID = Configuration.AppId;
            PromoCode =DiscountCode ;
        }


    }
}
