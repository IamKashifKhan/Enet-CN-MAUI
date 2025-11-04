using System;

namespace EnetCNMAUI.Domain.Models.MVC
{
    public class OffersMapItem
    {
        public int BusinessOffersKey { get; set; }
        public int BusinessKey { get; set; }
        public string BusinessName { get; set; }
        public string BusinessLogoPath { get; set; }
        public string BusinessProfileImagePath { get; set; }
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
        public double Value { get; set; }
        public double Discount { get; set; }
        public double FinalValue { get; set; }
        public bool isAutoRenew { get; set; }
        public int OfferViews { get; set; }
        public int RedemptionsCount { get; set; }
        public int isFavorite { get; set; }
        public int isUsed { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
