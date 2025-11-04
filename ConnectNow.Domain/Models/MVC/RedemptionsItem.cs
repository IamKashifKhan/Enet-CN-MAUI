using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.Domain.Models.MVC
{
    public class RedemptionsItem
    {
        public int BusinessKey { get; set; }
        public string BusinessName { get; set; }
        public int BusinessOffersKey { get; set; }
        public string ThumbnailPath { get; set; }
        public string ImagePath { get; set; }
        public string CodeImage_ThumbnailPath { get; set; }
        public string CodeImage_Path { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public string RedemptionCode { get; set; }
        public string ConfirmationCode { get; set; }
        public string RedemptionType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsActive { get; set; }
        public Decimal Value { get; set; }
        public Decimal Discount { get; set; }
        public Decimal FinalValue { get; set; }
        public bool isAutoRenew { get; set; }
        public int OfferViews { get; set; }
        public DateTime RedemptionTimestamp { get; set; }
    }
}
