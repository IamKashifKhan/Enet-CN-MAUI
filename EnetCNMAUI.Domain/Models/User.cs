using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace EnetCNMAUI.Models
{
    public class User
    {
        [JsonProperty(PropertyName = "User_db_Users_ID")]
        public string User_db_Users_ID { get; set; }
        [JsonProperty(PropertyName = "User_dbNickName")]

        public string User_dbNickName { get; set; }
        [JsonProperty(PropertyName = "User_dbFirstName")]

        public string User_dbFirstName { get; set; }
        [JsonProperty(PropertyName = "User_dbLastName")]

        public string User_dbLastName { get; set; }
        [JsonProperty(PropertyName = "User_dbEmail")]

        public string User_dbEmail { get; set; }
        [JsonProperty(PropertyName = "User_dbPassword")]

        public string User_dbPassword { get; set; }

        [JsonProperty(PropertyName = "User_dbTempPhone")]

        public string User_dbTempPhone { get; set; }

        [JsonProperty(PropertyName = "User_dbPhone")]

        public string User_dbPhone { get; set; }

        [JsonProperty(PropertyName = "User_dbDoB")]

        public string User_dbDoB { get; set; }

        [JsonProperty(PropertyName = "User_dbCountry")]

        public string User_dbCountry { get; set; }

        [JsonProperty(PropertyName = "User_dbCity")]

        public string User_dbCity { get; set; }

        [JsonProperty(PropertyName = "User_dbState")]

        public string User_dbState { get; set; }

        [JsonProperty(PropertyName = "User_dbAddress")]

        public string User_dbAddress { get; set; }

        [JsonProperty(PropertyName = "User_dbZipcode")]

        public string User_dbZipcode { get; set; }

        [JsonProperty(PropertyName = "User_dbLatitude")]

        public string User_dbLatitude { get; set; }

        [JsonProperty(PropertyName = "User_dbLongitude")]

        public string User_dbLongitude { get; set; }

        [JsonProperty(PropertyName = "User_dbImagePath")]

        public string User_dbImagePath { get; set; }

        [JsonProperty(PropertyName = "User_dbCoverImagePath")]

        public string User_dbCoverImagePath { get; set; }

        [JsonProperty(PropertyName = "User_dbHobby")]

        public string User_dbHobby { get; set; }

        [JsonProperty(PropertyName = "User_dbMarried")]

        public string User_dbMarried { get; set; }

        [JsonProperty(PropertyName = "User_dbAbout")]

        public string User_dbAbout { get; set; }

        [JsonProperty(PropertyName = "User_dbCompany")]

        public string User_dbCompany { get; set; }

        [JsonProperty(PropertyName = "User_dbTimestamp")]

        public string User_dbTimestamp { get; set; }

        [JsonProperty(PropertyName = "User_dbDeviceRegistrationToken")]

        public string User_dbDeviceRegistrationToken { get; set; }

        [JsonProperty(PropertyName = "User_dbPNSTags")]

        public string User_dbPNSTags { get; set; }

        [JsonProperty(PropertyName = "User_dbReferral")]

        public string User_dbReferral { get; set; }

        [JsonProperty(PropertyName = "User_dbISNonTLP")]

        public string User_dbISNonTLP { get; set; }

        [JsonProperty(PropertyName = "User_dbVerificationCode")]

        public string User_dbVerificationCode { get; set; }

        [JsonProperty(PropertyName = "User_dbActive")]

        public string User_dbActive { get; set; }

        [JsonProperty(PropertyName = "User_dbisUser")]

        public string User_dbisUser { get; set; }

        [JsonProperty(PropertyName = "User_dbisBusiness")]

        public string User_dbisBusiness { get; set; }

        [JsonProperty(PropertyName = "User_dbisChannel")]

        public string User_dbisChannel { get; set; }

        [JsonProperty(PropertyName = "User_dbTimezone")]

        public string User_dbTimezone { get; set; }

        [JsonProperty(PropertyName = "User_dbisDST")]

        public string User_dbisDST { get; set; }

        [JsonProperty(PropertyName = "User_dbGender")]

        public string User_dbGender { get; set; }

        [JsonProperty(PropertyName = "User_dbWorkInfo")]

        public string User_dbWorkInfo { get; set; }

        //public class AuthenticatUser
        //{
        //    public string status { get; set; }
        //    public Data data { get; set; }

        //}
        //public class Data
        //{
        //    public string id { get; set; }
        //    public string name { get; set; }
        //    public string phone { get; set; }
        //    public string email { get; set; }
        //    public string role { get; set; }
        //    public string districtId { get; set; }
        //    public string districtName { get; set; }
        //}
    }

    public class UserMenu
    {
        public string Item { get; set; }
        public string ImagePath { get; set; }
        public string ActiveImagePath { get; set; }
        public string PageReference { get; set; }
        public string MenuOrder { get; set; }
    }

    public class UpdateUserModel
    {
        public string UserKey { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string DOB { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string LanID { get; set; }
        public string LanName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ImagePath { get; set; }
        public string CoverImagePath { get; set; }
        public string Active { get; set; }
        public string RegistrationTimestamp { get; set; }
        public string Hobby { get; set; }
        public string Married { get; set; }
        public string About { get; set; }
        public string Gender { get; set; }
        public string Company { get; set; }
    }

}
