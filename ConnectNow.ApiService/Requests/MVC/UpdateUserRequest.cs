using Newtonsoft.Json;
using ConnectNow.Models;
using ConnectNow.Domain.Models.MVC;

namespace ConnectNow.ApiService.Requests.MVC
{
    public class UpdateUserRequest
    {

        [JsonProperty(PropertyName = "Authorization")]
        public string Authorization { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public int UserKey { get; }

        [JsonProperty(PropertyName = "NickName")]
        public string NickName { get; }

        [JsonProperty(PropertyName = "FirstName")]
        public string FirstName { get; }

        [JsonProperty(PropertyName = "LastName")]
        public string LastName { get; }

        // [JsonProperty(PropertyName = "DoB")]
        // public string DoB { get; }

        [JsonProperty(PropertyName = "Country")]
        public string Country { get; }

        [JsonProperty(PropertyName = "City")]
        public string City { get; }

        [JsonProperty(PropertyName = "State")]
        public string State { get; }

        [JsonProperty(PropertyName = "Address")]
        public string Address { get; }

        [JsonProperty(PropertyName = "Latitude")]
        public string Latitude { get; }

        [JsonProperty(PropertyName = "Longitude")]
        public string Longitude { get; }

        [JsonProperty(PropertyName = "Hobby")]
        public string Hobby { get; }

        [JsonProperty(PropertyName = "Married")]
        public string Married { get; }

        [JsonProperty(PropertyName = "About")]
        public string About { get; }

        [JsonProperty(PropertyName = "Company")]
        public string Company { get; }

        [JsonProperty(PropertyName = "Timezone")]
        public string Timezone { get; }

        [JsonProperty(PropertyName = "IsDST")]
        public string IsDST { get; }

        [JsonProperty(PropertyName = "CC_Name")]
        public string CC_Name { get; }

        [JsonProperty(PropertyName = "CC_Type")]
        public string CC_Type { get; }

        [JsonProperty(PropertyName = "CC_Number")]
        public string CC_Number { get; }

        [JsonProperty(PropertyName = "CC_EXP_MM")]
        public string CC_EXP_MM { get; }

        [JsonProperty(PropertyName = "CC_EXP_YYYY")]
        public string CC_EXP_YYYY { get; }

        [JsonProperty(PropertyName = "CC_CODE")]
        public int CC_CODE { get; }

        [JsonProperty(PropertyName = "CC_AutoCharge")]
        public bool CC_AutoCharge { get; }

        [JsonProperty(PropertyName = "ImagePath")]
        public string ImagePath { get; }

        [JsonProperty(PropertyName = "CoverImagePath")]
        public string CoverImagePath { get; }

        [JsonProperty(PropertyName = "DeviceRegistrationToken")]
        public string DeviceRegistrationToken { get; }

        [JsonProperty(PropertyName = "PNSTags")]
        public string PNSTags { get; }

        [JsonProperty(PropertyName = "Referral")]
        public string Referral { get; }

        [JsonProperty(PropertyName = "Email")]
        public string Email { get; }

        [JsonProperty(PropertyName = "ZipCode")]
        public string ZipCode { get; }


        public UpdateUserRequest(AALUser User)
        {
            Authorization = "123";
            UserKey = User.UserKey;
            NickName = User.NickName;
            FirstName = User.FirstName;
            LastName = User.LastName;
           // DoB = User.DoB.ToString();
            Country = User.Country;
            City = User.City;
            Address = User.Address;
            Latitude = User.Latitude.ToString();
            Longitude = User.Longitude.ToString();
            About = User.About;
            Company = User.Company;
            Timezone = User.Timezone;
            Married = User.Married;
            Hobby = User.Hobby;
            ImagePath = User.ImagePat;
            CoverImagePath = User.CoverImagePath;
            IsDST = User.IsDST;
            CC_AutoCharge = User.CC_AutoCharge;
            CC_CODE = User.CC_CODE;
            CC_EXP_MM = User.CC_EXP_MM.ToString();
            CC_EXP_YYYY = User.CC_EXP_YYYY.ToString();
            CC_Name = User.CC_Name;
            CC_Number = User.CC_Number;
            CC_Type = User.CC_Type;
            DeviceRegistrationToken = User.DeviceRegistrationToken;
            PNSTags = User.PNSTags;
            Referral = User.Referral;
            Email = User.Email;
            ZipCode = User.Zipcode;
        }
    }
}
