using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.ApiService.Requests.MVC
{
    public class UnsubscribeTopicRequest
    {
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }

        [JsonProperty(PropertyName = "NotificationTopic")]
        public string NotificationTopic { get; }

        public UnsubscribeTopicRequest(string userKey, string topic)
        {
            Authorization = Configuration.Authorization;
            UserKey = userKey;
            NotificationTopic = topic;
        }
    }
}
