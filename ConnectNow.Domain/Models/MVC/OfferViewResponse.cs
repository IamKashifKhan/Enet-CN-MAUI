using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.Domain.Models.MVC
{
    public class OfferViewResponse
    {
        public object AAL_tbl_Business { get; set; }
        // The following collections have been commented out as they were in the original sample.
        // public List<object> AAL_tbl_Users_BusinessOffers_Connection { get; set; }
        // public List<object> AAL_tbl_Business_Redemptions { get; set; }
        public int BusinessOffersKey { get; set; }
        public int BusinessKey { get; set; }
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
        public object Timestamp { get; set; }
        public bool IsActive { get; set; }
        public double Value { get; set; }
        public double Discount { get; set; }
        public double FinalValue { get; set; }
        public bool isAutoRenew { get; set; }
        public int OfferViews { get; set; }
    }
}
