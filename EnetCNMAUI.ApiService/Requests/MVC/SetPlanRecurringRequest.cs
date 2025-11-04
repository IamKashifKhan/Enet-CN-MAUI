using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnetCNMAUI.ApiService.Requests.MVC
{
    public class SetPlanRecurringRequest
    {
        // [AliasAs("email")]
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "IsRecurring")]
        public string IsRecurring { get; }

        [JsonProperty(PropertyName = "UserSubscriptionPlanKey")]
        public string UserSubscriptionPlanKey { get; }

        public SetPlanRecurringRequest(bool isRecurring, string userSubscriptionPlanKey)
        {
            Authorization = Configuration.Authorization;
            IsRecurring = isRecurring.ToString();
            UserSubscriptionPlanKey = userSubscriptionPlanKey;
        }
    }
}
