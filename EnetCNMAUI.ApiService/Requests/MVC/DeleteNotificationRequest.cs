using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnetCNMAUI.ApiService.Requests.MVC
{
    public class DeleteNotificationRequest
    {
        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "Notification_ID")]
        public string Notification_ID { get; }

        public DeleteNotificationRequest(string notificationID)
        {
            Authorization = Configuration.Authorization;
            Notification_ID = notificationID;
        }
    }
}
