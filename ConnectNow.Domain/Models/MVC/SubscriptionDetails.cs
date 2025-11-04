using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.Domain.Models.MVC
{
    public class SubscriptionDetails
    {
        public int UserSubscriptionKey { get; set; }
        public int UserKey { get; set; }
        public int UserSubscriptionPlanKey { get; set; }
        public string Availed_Discount_Code { get; set; }
        public DateTime SubscriptionStart { get; set; }
        public DateTime SubscriptionEnd { get; set; }
        public bool IsActive { get; set; }
    }
}
