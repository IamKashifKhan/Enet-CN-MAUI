using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnetCNMAUI.Domain.Models.MVC
{
    public class UserNotificationItem
    {
        public object AAL_tbl_Users { get; set; }
        public object AAL_tbl_Users1 { get; set; }
        public int Notification_ID { get; set; }
        public int Sender_UserKey { get; set; }
        public int Receiver_UserKey { get; set; }
        public string Sender_isApp_isBusiness_isUser { get; set; }
        public string Receiver_isApp_isBusiness_isUser { get; set; }
        public string Message { get; set; }
        public object ImagePath { get; set; }
        public DateTime Timestamp { get; set; }
        public object Parent_Notification_ID { get; set; }
        public object IsReplyPossible { get; set; }
        public string NotificationType { get; set; }
        public string Heading { get; set; }
    }
}
