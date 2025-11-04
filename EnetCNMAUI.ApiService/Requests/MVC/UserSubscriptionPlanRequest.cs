using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnetCNMAUI.ApiService.Requests.MVC
{
    public class UserSubscriptionPlanRequest
    {
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }


        [JsonProperty(PropertyName = "UserKey")]
        public int UserKey { get; }

        [JsonProperty(PropertyName = "APPID")]
        public string APPID { get; }


        public UserSubscriptionPlanRequest(int userKey)
        {
            Authorization = Configuration.Authorization;
            UserKey = userKey;
            APPID = Configuration.AppId;
        }
    }
}
