using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.Domain.Models.MVC
{
    public class AALUser
    {
        public int UserKey { get; set; }
        public string APPID { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string TempPhone { get; set; }
        public string Phone { get; set; }
        public DateTime DoB { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ImagePat { get; set; }
        public string CoverImagePath { get; set; }
        public string Hobby { get; set; }
        public string Married { get; set; }
        public string About { get; set; }
        public string Company { get; set; }
        public string DeviceRegistrationToken { get; set; }
        public string PNSTags { get; set; }
        public string Referral { get; set; }
        public bool ISNonAppUser { get; set; }
        public string VerificationCode { get; set; }
        public DateTime VerificationCodeTime { get; set; }
        public bool IsBusinessAdmin { get; set; }
        public string Timezone { get; set; }
        public string IsDST { get; set; }
        public string CC_Name { get; set; }
        public string CC_Type { get; set; }
        public string CC_Number { get; set; }
        public int CC_EXP_MM { get; set; }
        public int CC_EXP_YYYY { get; set; }
        public int CC_CODE { get; set; }
        public bool CC_AutoCharge { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegistrationTimestamp { get; set; }
    }
}
