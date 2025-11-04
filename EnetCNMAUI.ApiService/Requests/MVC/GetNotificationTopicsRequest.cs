using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnetCNMAUI.ApiService.Requests.MVC
{
    public class GetNotificationTopicsRequest
    {
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }

        public GetNotificationTopicsRequest(string userKey)
        {
            Authorization = Configuration.Authorization;
            UserKey = userKey;
        }
    }
}
