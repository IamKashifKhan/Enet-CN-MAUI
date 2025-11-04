using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnetCNMAUI.Domain.Models.MVC
{
    public class BusinessOfferItem
    {
        public List<BusinessCategory> BusinessCategory { get; set; }

        public int BusinessOffersKey { get; set; }
        public string BusinessLogoPath { get; set; }
        public int BusinessKey { get; set; }
        public string BusinessName { get; set; }
        public string ThumbnailPath { get; set; }
        public string BusinessProfileImagePath { get; set; }
        public string ImagePath { get; set; }
        public string CodeImage_ThumbnailPath { get; set; }
        public string CodeImage_Path { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public string RedemptionCode { get; set; }
        public string ConfirmationCode { get; set; }
        public string RedemptionType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Timestamp { get; set; }
        public bool IsActive { get; set; }
        public double Value { get; set; }
        public double Discount { get; set; }
        public double FinalValue { get; set; }
        public bool isAutoRenew { get; set; }
        public int OfferViews { get; set; }
        public int RedemptionsCount { get; set; }

        // Removed IsActivePlane field notification and converted to a simple public field.
        public bool IsActivePlane { get; set; }
        public bool ShowRedemptionLabel { get; set; }

        public bool IsActivePlan { get; set; }
        public bool isUsed { get; set; }
        public bool isFavorite { get; set; }
        public bool IsRedeemable { get; set; }
    }
    public class BusinessCategory
    {
        public string SubCategory { get; set; }
        public int SubCategoryKey { get; set; }
    }

}
