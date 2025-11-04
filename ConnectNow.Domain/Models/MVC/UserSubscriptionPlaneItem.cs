using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.Domain.Models.MVC
{
    public class UserSubscriptionPlaneItem
    {
        public int UserSubscriptionPlanKey { get; set; }
        public string APPID { get; set; }
        public string UserSubscriptionName { get; set; }
        public int? OffersRedemptionBucket { get; set; }
        public string Description { get; set; }
        public double SetupFee { get; set; }
        public int BillingCycle { get; set; }
        public double Fee { get; set; }
        public double? EnrolmentBonus { get; set; }
        public double TotalFee { get; set; }
        public string ImagePath { get; set; }
        public string HeadingText { get; set; }
        public string DescriptionText { get; set; }
        public bool SelectedPlan { get; set; }
        public bool IsActive { get; set; }
        public bool isRecurring { get; set; }
        public bool isOffersOnly { get; set; }
    }
}
