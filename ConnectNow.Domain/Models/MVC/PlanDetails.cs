using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.Domain.Models.MVC
{
    public class PlanDetails
    {
        public int UserSubscriptionKey { get; set; }
        public int UserSubscriptionPlanKey { get; set; }
        public bool IsActive { get; set; }
        public string PlanName { get; set; }
        public DateTime SubscriptionStart { get; set; }
        public DateTime SubscriptionEnd { get; set; }
        public bool isRecurring { get; set; }
    }
}
