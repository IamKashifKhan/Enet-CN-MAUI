using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnetCNMAUI.Domain.Models.MVC
{
    public class BusinessItem
    {
        public int BusinessKey { get; set; }
        public string APPID { get; set; }
        public string BusinessProductKey { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Email { get; set; }
        public string ThumbnailPath { get; set; }
        public string ProfileImagePath { get; set; }
        public string LogoPath { get; set; }
        public string About { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public bool? Published { get; set; }
        public bool? NotifyBySMS { get; set; }
        public bool? OutBoundSMS { get; set; }
        public string DefaultSMSForwardPhone { get; set; }
        public string TopBar_BackgroundColor { get; set; }
        public string TopBar_TextColor { get; set; }
        public string SideBar_BackgroundColor { get; set; }
        public string SideBar_TextColor { get; set; }
        public int CategoryLimit { get; set; }
        public int? OffersBucket { get; set; }
        public int? SMSBucket { get; set; }
        public int? EventsBucket { get; set; }
        public int NewsBucket { get; set; }
        public int FeedsBucket { get; set; }
        public int PollsBucket { get; set; }
        public int? PushNotificationBucket { get; set; }
        public DateTime? LastPaymentDate { get; set; }
        public string NextPaymentDueDate { get; set; }
        public DateTime RegistrationTimestamp { get; set; }
        public string CC_Name { get; set; }
        public string CC_Type { get; set; }
        public string CC_Number { get; set; }
        public int? CC_EXP_MM { get; set; }
        public int? CC_EXP_YYYY { get; set; }
        public int? CC_CODE { get; set; }
        public bool CC_AutoCharge { get; set; }
        public bool IsActive { get; set; }
        public int ActiveOffersCount { get; set; }

        public bool favorite { get; set; }
    }
}
