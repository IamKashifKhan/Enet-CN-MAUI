namespace EnetCNMAUI.Models
{
    public class BusinessBasicDetailItem 
    {
        public string IsFavorite { get; set; }
        public string BusinessKey { get; set; }
        public string BusinessName { get; set; }
        public string Profile { get; set; }
        public string Logo { get; set; }
        public string About { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
       // public string Phone { get; set; }
        //public string Phone
        //{


        //    get { return phone; }
        //    set
        //    {
        //        OnPropertyChanged(nameof(phone));
        //    }
        //}

         public string Phone { get; set; }
        

        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string PaymentTermsKey { get; set; }
        public string SubscriptionType { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string GooglePlus { get; set; }
        public string LinkedIn { get; set; }
        public string Pinterest { get; set; }
        public string Tumblr { get; set; }
        public string Instagram { get; set; }
        public string Youtube { get; set; }
        public string RSS { get; set; }
        public string BusinessKey1 { get; set; }
        public string StartTime_Sunday { get; set; }
        public string EndTime_Sunday { get; set; }
        public string StartTime_Monday { get; set; }
        public string EndTime_Monday { get; set; }
        public string StartTime_Tuesday { get; set; }
        public string EndTime_Tuesday { get; set; }
        public string StartTime_Wednesday { get; set; }
        public string EndTime_Wednesday { get; set; }
        public string StartTime_Thursday { get; set; }
        public string EndTime_Thursday { get; set; }
        public string StartTime_Friday { get; set; }
        public string EndTime_Friday { get; set; }
        public string StartTime_Saturday { get; set; }
        public string EndTime_Saturday { get; set; }
        public string BusinessTimeZone { get; set; }
        public string TimeDiff { get; set; }
        public string DST { get; set; }
        public string Timestamp { get; set; }
    }


    public class ZipCodetoLocationItem
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    public class BusinessImagesItem
    {
        public string BusinessImageKey { get; set; }
        public string BusinessKey { get; set; }
        public string Thumbnail { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Timestamp { get; set; }

    }

    public class BusinessScheduleItem
    {
        public string BusinessKey { get; set; }
        public string StartTime_Sunday { get; set; }
        public string EndTime_Sunday { get; set; }
        public string StartTime_Monday { get; set; }
        public string EndTime_Monday { get; set; }
        public string StartTime_Tuesday { get; set; }
        public string EndTime_Tuesday { get; set; }
        public string StartTime_Wednesday { get; set; }
        public string EndTime_Wednesday { get; set; }
        public string StartTime_Thursday { get; set; }
        public string EndTime_Thursday { get; set; }
        public string StartTime_Friday { get; set; }
        public string EndTime_Friday { get; set; }
        public string StartTime_Saturday { get; set; }
        public string EndTime_Saturday { get; set; }
        public string BusinessTimeZone { get; set; }
        public string TimeDiff { get; set; }
        public string DST { get; set; }
        public string Timestamp { get; set; }
    }

    public class BusinessOffersItem
    {
        public string IsFavorite { get; set; }
        public string OfferKey { get; set; }
        public string BusinessKey { get; set; }
        public string ThumbnailPath { get; set; }
        public string ImagePath { get; set; }
        public string CodeThumbnailPath { get; set; }
        public string CodeImagePath { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public string BusinessName { get; set; }
        public string Timestamp { get; set; }
    }

    public class BusinessSocialItem
    {
        public string BusinessKey { get; set; }
        public string Pltform { get; set; }
        public string IconPath { get; set; }
        public string Link { get; set; }
    }

    public class BusinessReviews
    {
        public int ReviewKey { get; set; }
        public int BusinessKey { get; set; }
        public int UserKey { get; set; }
        public string UserNickname { get; set; }
        public string UserImagePath { get; set; }
        public string Reivew { get; set; }
        public int Points { get; set; }
        public int AverageReviews { get; set; }
        public string Timestamp { get; set; }
    }
    public class StatusItem
    {
        public string Status { get; set; }
    }


    public class BusinessReviewsSummary
    {
        public long ReviewPoints { get; set; }
        public long ReviewCount { get; set; }
        public long TotalReviews { get; set; }
        public long AverageReviews { get; set; }
    }
}

