using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.ApiService.Requests.MVC
{
    public class SubscribeTopicRequest
    {
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "APPID")]
        public string APPID { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }

        [JsonProperty(PropertyName = "NotificationTopic")]
        public string NotificationTopic { get; }

        [JsonProperty(PropertyName = "DevicePlatform")]
        public string DevicePlatform { get; }





        public SubscribeTopicRequest(string userkey, string topic)
        {
            APPID = Configuration.AppId;
            Authorization = Configuration.Authorization;
            UserKey = userkey;
            NotificationTopic = topic;
            DevicePlatform = (Device.RuntimePlatform == Device.iOS ? "ios" : "android");
        }
    }
}
