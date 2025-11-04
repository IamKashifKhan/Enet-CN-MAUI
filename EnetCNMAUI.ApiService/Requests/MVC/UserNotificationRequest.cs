using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnetCNMAUI.ApiService.Requests.MVC
{
    public class UserNotificationRequest
    {
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "ReceiverUserKey")]
        public string ReceiverUserKey { get; }

        public UserNotificationRequest(string receiverUserKeyserkey)
        {
            Authorization = Configuration.Authorization;
            ReceiverUserKey = receiverUserKeyserkey;
        }
    }
}
