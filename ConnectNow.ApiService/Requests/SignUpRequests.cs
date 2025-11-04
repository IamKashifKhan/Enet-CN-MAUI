using System;
using ConnectNow.Helpers;
using ConnectNow.Models;
using Newtonsoft.Json;

namespace ConnectNow.Requests
{
    public class RegisterRequest
    {
        [JsonProperty(PropertyName = "dbPhone")]
        public string dbPhone { get; }

        //  [AliasAs("password")]
        [JsonProperty(PropertyName = "dbEmail")]
        public string dbEmail { get; }


        [JsonProperty(PropertyName = "AuthorizationKey")]

        public string AuthorizationKey { get; }

        public RegisterRequest(string dbemail, string dbphone)
        {
            dbEmail = dbemail;
            dbPhone = dbphone;
            AuthorizationKey = Configuration.AuthorizationKey;
        }
    }
    public class VerifyCodeRequest
    {
        [JsonProperty(PropertyName = "dbPhone")]
        public string dbPhone { get; }

        //  [AliasAs("password")]
        [JsonProperty(PropertyName = "dbEmail")]
        public string dbEmail { get; }


        [JsonProperty(PropertyName = "AuthorizationKey")]

        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "dbVerificationCode")]

        public string dbVerificationCode { get; }
        

        public VerifyCodeRequest(string dbemail, string dbphone, string dbverificationCode)
        {
            dbEmail = dbemail;
            dbPhone = dbphone;
            dbVerificationCode = dbverificationCode;
            AuthorizationKey = Configuration.AuthorizationKey;
        }
    }
    public class UpadteUserRequest 
    {
        [JsonProperty(PropertyName = "AuthorizationKey")]

        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "User_db_Users_ID")]
        public string User_db_Users_ID { get; }
        [JsonProperty(PropertyName = "User_dbNickName")]

        public string User_dbNickName { get; }
        [JsonProperty(PropertyName = "User_dbFirstName")]

        public string User_dbFirstName { get; }
        [JsonProperty(PropertyName = "User_dbLastName")]

        public string User_dbLastName { get; }
        [JsonProperty(PropertyName = "User_dbEmail")]

        public string User_dbEmail { get; }
        [JsonProperty(PropertyName = "User_dbPassword")]

        public string User_dbPassword { get; }

        [JsonProperty(PropertyName = "User_dbTempPhone")]

        public string User_dbTempPhone { get; }

        [JsonProperty(PropertyName = "User_dbPhone")]

        public string User_dbPhone { get; }

        [JsonProperty(PropertyName = "User_dbDoB")]

        public string User_dbDoB { get; }

        [JsonProperty(PropertyName = "User_dbCountry")]

        public string User_dbCountry { get; }

        [JsonProperty(PropertyName = "User_dbCity")]

        public string User_dbCity { get; }

        [JsonProperty(PropertyName = "User_dbState")]

        public string User_dbState { get; }

        [JsonProperty(PropertyName = "User_dbAddress")]

        public string User_dbAddress { get; }

        [JsonProperty(PropertyName = "User_dbZipcode")]

        public string User_dbZipcode { get; }

        [JsonProperty(PropertyName = "User_dbLatitude")]

        public string User_dbLatitude { get; }

        [JsonProperty(PropertyName = "User_dbLongitude")]

        public string User_dbLongitude { get; }

        [JsonProperty(PropertyName = "User_dbImagePath")]

        public string User_dbImagePath { get; }

        [JsonProperty(PropertyName = "User_dbCoverImagePath")]

        public string User_dbCoverImagePath { get; }

        [JsonProperty(PropertyName = "User_dbHobby")]

        public string User_dbHobby { get; }

        [JsonProperty(PropertyName = "User_dbMarried")]

        public string User_dbMarried { get; }

        [JsonProperty(PropertyName = "User_dbAbout")]

        public string User_dbAbout { get; }

        [JsonProperty(PropertyName = "User_dbCompany")]

        public string User_dbCompany { get; }

        [JsonProperty(PropertyName = "User_dbTimestamp")]

        public string User_dbTimestamp { get; }

        [JsonProperty(PropertyName = "User_dbDeviceRegistrationToken")]

        public string User_dbDeviceRegistrationToken { get; }

        [JsonProperty(PropertyName = "User_dbPNSTags")]

        public string User_dbPNSTags { get; }

        [JsonProperty(PropertyName = "User_dbReferral")]

        public string User_dbReferral { get; }

        [JsonProperty(PropertyName = "User_dbISNonTLP")]

        public string User_dbISNonTLP { get; }

        [JsonProperty(PropertyName = "User_dbVerificationCode")]

        public string User_dbVerificationCode { get; }

        [JsonProperty(PropertyName = "User_dbActive")]

        public string User_dbActive { get; }

        [JsonProperty(PropertyName = "User_dbisUser")]

        public string User_dbisUser { get; }

        [JsonProperty(PropertyName = "User_dbisBusiness")]

        public string User_dbisBusiness { get; }

        [JsonProperty(PropertyName = "User_dbisChannel")]

        public string User_dbisChannel { get; }

        [JsonProperty(PropertyName = "User_dbTimezone")]

        public string User_dbTimezone { get; }

        [JsonProperty(PropertyName = "User_dbisDST")]

        public string User_dbisDST { get; }

        [JsonProperty(PropertyName = "User_dbGender")]

        public string User_dbGender { get; }

        [JsonProperty(PropertyName = "User_dbWorkInfo")]

        public string User_dbWorkInfo { get; }


        //public UpadteUserRequest(User User )
        //{
        //    User_db_Users_ID = User.User_db_Users_ID;
        //    User_dbNickName = User.User_dbNickName;
        //    User_dbFirstName = User.User_dbFirstName;
        //    User_dbLastName = User.User_dbLastName;
        //    User_dbEmail = User.User_dbEmail;
        //    //   User_dbPassword = User.User_dbPassword;
        //    User_dbTempPhone = User.User_dbTempPhone;
        //    User_dbPhone = User.User_dbPhone;
        //    User_dbDoB = User.User_dbDoB;
        //    User_dbCountry = User.User_dbCountry;
        //    User_dbCity = User.User_dbCity;
        //    User_dbState = User.User_dbState;
        //    User_dbAddress = User.User_dbAddress;
        //    User_dbZipcode = User.User_dbZipcode;
        //    User_dbLatitude = User.User_dbLatitude;
        //    User_dbLongitude = User.User_dbLongitude;
        //    User_dbImagePath = User.User_dbImagePath;
        //    User_dbCoverImagePath = User.User_dbCoverImagePath;
        //    User_dbHobby = User.User_dbHobby;
        //    User_dbMarried = User.User_dbMarried;
        //    User_dbAbout = User.User_dbAbout;
        //    User_dbCompany = User.User_dbCompany;
        //    User_dbTimestamp = User.User_dbTimestamp;
        //    User_dbDeviceRegistrationToken = User.User_dbDeviceRegistrationToken;
        //    User_dbPNSTags = User.User_dbPNSTags;
        //    User_dbReferral = User.User_dbReferral;
        //    User_dbISNonTLP = User.User_dbISNonTLP;
        //    User_dbVerificationCode = User.User_dbVerificationCode;
        //    User_dbActive = User.User_dbActive;
        //    User_dbisUser = User.User_dbisUser;
        //    User_dbisBusiness = User.User_dbisBusiness;
        //    User_dbisChannel = User.User_dbisChannel;
        //    User_dbTimezone = User.User_dbTimezone;
        //    User_dbisDST = User.User_dbisDST;
        //    User_dbImagePath = User.User_dbImagePath;
        //    User_dbCoverImagePath = User.User_dbCoverImagePath;
        //    AuthorizationKey = Configuration.AuthorizationKey;
        //    User_dbGender = User.User_dbGender;
        //    User_dbWorkInfo = User.User_dbWorkInfo;
        //}

     }

    public class UpdateUserPrivacyRequestModel
    {
        public UpdateUserPrivacyRequestModel(string user_db_Users_ID, string user_dbHobby_Privacy, string user_dbMarried_Privacy, string user_dbAbout_Privacy, string user_dbGender_Privacy, string user_dbCompany_Privacy, string user_dbWorkInfo_Privacy)
        {
            User_db_Users_ID = user_db_Users_ID;
            AuthorizationKey = Configuration.AuthorizationKey; 
            User_dbHobby_Privacy = user_dbHobby_Privacy;
            User_dbMarried_Privacy = user_dbMarried_Privacy;
            User_dbAbout_Privacy = user_dbAbout_Privacy;
            User_dbGender_Privacy = user_dbGender_Privacy;
            User_dbCompany_Privacy = user_dbCompany_Privacy;
            User_dbWorkInfo_Privacy = user_dbWorkInfo_Privacy;
        }

        [JsonProperty(PropertyName = "User_db_Users_ID")]
        public string User_db_Users_ID { get; set; }

        [JsonProperty(PropertyName = "AuthorizationKey")]

        public string AuthorizationKey { get; set; }

        [JsonProperty(PropertyName = "User_dbHobby_Privacy")]
        public string User_dbHobby_Privacy { get; set; }

        [JsonProperty(PropertyName = "User_dbMarried_Privacy")]
        public string User_dbMarried_Privacy { get; set; }

        [JsonProperty(PropertyName = "User_dbAbout_Privacy")]
        public string User_dbAbout_Privacy { get; set; }

        [JsonProperty(PropertyName = "User_dbGender_Privacy")]
        public string User_dbGender_Privacy { get; set; }

        [JsonProperty(PropertyName = "User_dbCompany_Privacy")]
        public string User_dbCompany_Privacy { get; set; }

        [JsonProperty(PropertyName = "User_dbWorkInfo_Privacy")]
        public string User_dbWorkInfo_Privacy { get; set; }
       
    }



    public class AuthorizationKeyRequest
    {
       
        [JsonProperty(PropertyName = "AuthorizationKey")]

        public string AuthorizationKey { get; }

        public AuthorizationKeyRequest()
        {
            AuthorizationKey = Configuration.AuthorizationKey;
        }
    }

    

    public class GetZipFromLanRequest
    {

        [JsonProperty(PropertyName = "AuthorizationKey")]

        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "LANID")]

        public string LANID { get; }

        public GetZipFromLanRequest(string Lanid)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            LANID = Lanid;
        }
    }

    public class GetUserFeedRequest
    {

        [JsonProperty(PropertyName = "AuthorizationKey")]

        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "UserKey")]

        public string UserKey { get; }
        [JsonProperty(PropertyName = "DataCount")]

        public string DataCount { get; }

        [JsonProperty(PropertyName = "PageNo")]

        public string PageNo { get; }
        [JsonProperty(PropertyName = "ChildFeeds")]

        public string ChildFeeds { get; }
        
        public GetUserFeedRequest(string userkey, string datacount, string pageno, string childfeeds)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            UserKey = userkey;
            DataCount = datacount;
            PageNo = pageno;
            ChildFeeds = childfeeds;
        }
    }
    public class GetConnectionRequest
    {

        [JsonProperty(PropertyName = "AuthorizationKey")]

        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "UserKey")]

        public string UserKey { get; }
        [JsonProperty(PropertyName = "Rows")]

        public string Rows { get; }

        [JsonProperty(PropertyName = "PageNo")]

        public string PageNo { get; }
        [JsonProperty(PropertyName = "ConnectionType")]

        public string ConnectionType { get; }

        public GetConnectionRequest(string userkey, string rows, string pageno, string connectionType)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            UserKey = userkey;
            Rows = rows;
            PageNo = pageno;
            ConnectionType = connectionType;
        }
    }
    public class AddRemoveConnectionRequest
    {

        [JsonProperty(PropertyName = "AuthorizationKey")]

        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "ParentUserKey")]

        public string ParentUserKey { get; }
        [JsonProperty(PropertyName = "ChildUserKey")]

        public string ChildUserKey { get; }

        [JsonProperty(PropertyName = "AddRemove")]

        public string AddRemove { get; }
       

        public AddRemoveConnectionRequest(string parentuserkey, string childuserkey, string addremove)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            ParentUserKey = parentuserkey;
            AddRemove = addremove;
            ChildUserKey = childuserkey;
        }
    }
    public class SearchConnectionRequest
    {
        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }

        [JsonProperty(PropertyName = "PageNo")]
        public string PageNo { get; }

        [JsonProperty(PropertyName = "SearchString")]
        public string SearchString { get; }


        public SearchConnectionRequest(string userkey, string pageno, string searchstring)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            UserKey = userkey;
            PageNo = pageno;
            SearchString = searchstring;
        }
    }
    public class GetUserByIdRequest
    {
        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "db_Users_Id")]
        public string db_Users_Id { get; }

        public GetUserByIdRequest(string userkey)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            db_Users_Id = userkey;
        }
    }
    public class GetFeedCommentRequest
    {
        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }

        [JsonProperty(PropertyName = "FeedKey")]
        public string FeedKey { get; }

        public GetFeedCommentRequest(string userkey, string feedkey)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            UserKey = userkey;
            FeedKey = feedkey;
        }
    }
    public class AddFeedCommentRequest
    {
        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }

        [JsonProperty(PropertyName = "FeedKey")]
        public string FeedKey { get; }

        [JsonProperty(PropertyName = "Comment")]
        public string Comment { get; }

        public AddFeedCommentRequest(string userkey, string feedkey, string comment)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            UserKey = userkey;
            FeedKey = feedkey;
            Comment = comment;
        }
    }

    public class UserFeedRequest
    {
        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }

        [JsonProperty(PropertyName = "Feed")]
        public string Feed { get; }

        [JsonProperty(PropertyName = "BusinessKey")]
        public string BusinessKey { get; }

        [JsonProperty(PropertyName = "Subject")]
        public string Subject { get; }

        [JsonProperty(PropertyName = "Image")]
        public String Image { get; }

        [JsonProperty(PropertyName = "FeedType")]
        public string FeedType { get; }

        [JsonProperty(PropertyName = "FromDate")]
        public string FromDate { get; }

        [JsonProperty(PropertyName = "ToDate")]
        public string ToDate { get; }

        [JsonProperty(PropertyName = "Time")]
        public string Time { get; }

        [JsonProperty(PropertyName = "LANID")]
        public string LANID { get; }
         
        [JsonProperty(PropertyName = "FeedLink")]
        public string FeedLink { get; }

        

        public UserFeedRequest(string userkey, string feed, string businesskey, string subject, String image, string mediatype, string fromdate, string todate, string time, string lanid, string feedlink)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            UserKey = userkey;
            Subject = subject;
            Feed = feed;
            FeedType = mediatype;
            FromDate = fromdate;
            ToDate = todate;
            Time = time;
            LANID = lanid;
            Image = image;
            FeedLink = feedlink;
            BusinessKey = businesskey;
        }
    }

    public class CheckUserConnectionRequest
    {
        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "UserKey1")]
        public string UserKey1 { get; }

        [JsonProperty(PropertyName = "UserKey2")]
        public string UserKey2 { get; }

        public CheckUserConnectionRequest(string userkey1, string userkey2)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            UserKey1 = userkey1;
            UserKey2 = userkey2;
        }
    }

    public class AddDeleteFeedCommentEmojiRequest
    {
        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "FeedCommentKey")]
        public string FeedCommentKey { get; }

        [JsonProperty(PropertyName = "FeedorComment")]
        public string FeedorComment { get; }


        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }

        [JsonProperty(PropertyName = "Emoji")]
        public string Emoji { get; }


        public AddDeleteFeedCommentEmojiRequest(string userkey, string feedorcomment, string feedcommectkey, string emoji)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            FeedCommentKey = feedcommectkey;
            UserKey = userkey;
            FeedorComment = feedorcomment;
            Emoji = emoji;
        }
    }

    public class ShareFeedRequest
    {
        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "FeedKey")]
        public string FeedKey { get; }

        [JsonProperty(PropertyName = "ParentUserKey")]
        public string ParentUserKey { get; }


        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }

        [JsonProperty(PropertyName = "UserFeed")]
        public string UserFeed { get; }


        public ShareFeedRequest(string userkey, string feedkey, string parentuserkey, string userfeed)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            FeedKey = feedkey;
            UserKey = userkey;
            ParentUserKey = parentuserkey;
            UserFeed = userfeed;
        }
    }

    public class ApproveUserConnectionsRequest
    {
        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "ChildUserKey")]
        public string ChildUserKey { get; }

        [JsonProperty(PropertyName = "ParentUserKey")]
        public string ParentUserKey { get; }


        [JsonProperty(PropertyName = "Approved")]
        public string Approved { get; }

    
        public ApproveUserConnectionsRequest(string childuserkey, string parentuserkey, string approve)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            ChildUserKey = childuserkey;
            ParentUserKey = parentuserkey;
            Approved = approve;
        }
    }

    public class GetBusinessCategoriesRequest
    {
        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "Zipcode")]
        public string Zipcode { get; }

        [JsonProperty(PropertyName = "LanID")]
        public string LanID { get; }


        [JsonProperty(PropertyName = "Radius")]
        public string Radius { get; }


        public GetBusinessCategoriesRequest(string zipcode, string lanid, string radius)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            Zipcode = zipcode;
            LanID = lanid;
            Radius = radius;
        }
    }

    public class DeleteFeedRequest
    {
        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "FeedKey")]
        public string FeedKey { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }


        public DeleteFeedRequest(string feedkey, string userkey)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            FeedKey = feedkey;
            UserKey = userkey;
        }
    }
    public class EditFeedRequest
    {
        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "FeedKey")]
        public string FeedKey { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }

        [JsonProperty(PropertyName = "BusinessKey")]
        public string BusinessKey { get; }

        [JsonProperty(PropertyName = "Subject")]
        public string Subject { get; }

        [JsonProperty(PropertyName = "Feed")]
        public string Feed { get; }

        [JsonProperty(PropertyName = "MediaType")]
        public string MediaType { get; }

        [JsonProperty(PropertyName = "FromDate")]
        public string FromDate { get; }

        [JsonProperty(PropertyName = "ToDate")]
        public string ToDate { get; }

        [JsonProperty(PropertyName = "Time")]
        public string Time { get; }

        [JsonProperty(PropertyName = "LANID")]
        public string LANID { get; }



        public EditFeedRequest(string feedkey, string userkey, string businesskey, string subject, string feed, string mediatype, string fromdate, string todate, string time, string lanid )
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            FeedKey = feedkey;
            UserKey = userkey;
            BusinessKey = businesskey;
            Subject = subject;
            Feed = feed;
            MediaType = mediatype;
            FromDate = fromdate;
            ToDate = todate;
            Time = time;
            LANID = lanid;

        }
    }



    public class GetMessageListRequest 
    {
        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }

        [JsonProperty(PropertyName = "PageNo")]
        public string PageNo { get; }


        public GetMessageListRequest(string userkey, string pageno)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            UserKey = userkey;
            PageNo = pageno;
        }
    }

    public class GetMessagesRequest
    {
        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }

        [JsonProperty(PropertyName = "MessagingKey")]
        public string MessagingKey { get; }

        [JsonProperty(PropertyName = "LastMessageKey")]
        public string LastMessageKey { get; }


        

        public GetMessagesRequest(string userkey, string messagingkey, string lastmessagekey)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            UserKey = userkey;
            MessagingKey = messagingkey;
            LastMessageKey = lastmessagekey;
        }
    }
    public class SendMessageRequest
    {
        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "SenderUserKey")]
        public string SenderUserKey { get; }

        [JsonProperty(PropertyName = "MessagingKey")]
        public string MessagingKey { get; }

        [JsonProperty(PropertyName = "ReceiverUserKey")]
        public string ReceiverUserKey { get; }

        [JsonProperty(PropertyName = "MessageDetails")]
        public string MessageDetails { get; }

        [JsonProperty(PropertyName = "ReceiverBusinessKey")]
        public string ReceiverBusinessKey { get; }

        


        public SendMessageRequest(string sendeuserkey, string receiveruserkey, string messagingkey, string messagedetail, string receiverbusinnesskey)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            SenderUserKey = sendeuserkey;
            ReceiverBusinessKey = receiverbusinnesskey;
            MessagingKey = messagingkey;
            MessageDetails = messagedetail;
            ReceiverBusinessKey = receiverbusinnesskey;
        }
    }

    public class GetBusinessFeedRequest
    {
        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "PageNo")]
        public string PageNo { get; }

        [JsonProperty(PropertyName = "Latitude")]
        public string Latitude { get; }

        [JsonProperty(PropertyName = "Longitude")]
        public string Longitude { get; }

        [JsonProperty(PropertyName = "Zipcode")]
        public string Zipcode { get; }

        [JsonProperty(PropertyName = "Radius")]
        public string Radius { get; }

        [JsonProperty(PropertyName = "LANID")]
        public string LANID { get; }

        [JsonProperty(PropertyName = "StartDate")]
        public string StartDate { get; }

        [JsonProperty(PropertyName = "DownDays")]
        public string DownDays { get; }


        [JsonProperty(PropertyName = "NoGlobalFeed")]
        public string NoGlobalFeed { get; }

        [JsonProperty(PropertyName = "BusinessKey")]
        public string BusinessKey { get; }




        public GetBusinessFeedRequest(string pageno, string lat, string longitude, string zipcode, string radius, string lanid, string startdate, string downdays, string noglobalfeed, string businesskey = "")
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            PageNo = pageno;
            Latitude = lat;
            Zipcode = zipcode;
            Radius = radius;
            LANID = lanid;
            StartDate = startdate;
            DownDays = downdays;
            NoGlobalFeed = noglobalfeed;
            BusinessKey = businesskey;
        }

        
    }
    public class GetBusinessListRequest
    {
        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }

        [JsonProperty(PropertyName = "PageNo")]
        public string PageNo { get; }

        [JsonProperty(PropertyName = "Latitude")]
        public string Latitude { get; }

        [JsonProperty(PropertyName = "Longitude")]
        public string Longitude { get; }

        [JsonProperty(PropertyName = "CategorySub")]
        public string CategorySub { get; }

        [JsonProperty(PropertyName = "Radius")]
        public string Radius { get; }

        [JsonProperty(PropertyName = "LanID")]
        public string LanID { get; }


        [JsonProperty(PropertyName = "Zipcode")]
        public string Zipcode { get; }


        public GetBusinessListRequest(string userkey, string pageno, string lat, string longitude, string category, string radius, string lanid, string zipcode)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            UserKey = userkey;
            PageNo = pageno;
            Latitude = lat;
            Longitude = longitude;
            CategorySub = category;
            Radius = radius;
            LanID = lanid;
            Zipcode = zipcode;
        }
    }
    public class GetOffersListRequest
    {
        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }

        [JsonProperty(PropertyName = "PageNo")]
        public string PageNo { get; }

        [JsonProperty(PropertyName = "Zipcode")]
        public string Zipcode { get; }

        [JsonProperty(PropertyName = "Radius")]
        public string Radius { get; }

        [JsonProperty(PropertyName = "LanID")]
        public string LanID { get; }

        public GetOffersListRequest(string userkey, string pageno, string zipcode,  string radius, string lanid)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            UserKey = userkey;
            PageNo = pageno;
            Zipcode = zipcode;
            Radius = radius;
            LanID = lanid;
        }
    }
    //public class EventRequest
    //{
    //    // [AliasAs("email")]
    //    [JsonProperty(PropertyName = "AuthorizationKey")]
    //    public string Authorization { get; }


    //    [JsonProperty(PropertyName = "APPID")]
    //    public string APPID { get; }

    //    [JsonProperty(PropertyName = "UserKey")]
    //    public string UserKey { get; }

    //    public EventRequest(string userkey)
    //    {
    //        Authorization = "";
    //        APPID = "AAL_Mindy";
    //        UserKey = userkey;
    //    }
    //}
    public class ChannelRegisterRequest  
    {
        
        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }


        [JsonProperty(PropertyName = "LANNAme")]
        public string LANNAme { get; }

        [JsonProperty(PropertyName = "Users_ID")]
        public string Users_ID { get; }

        [JsonProperty(PropertyName = "Type")]
        public string Type { get; }

        [JsonProperty(PropertyName = "About")]
        public string About { get; }

        [JsonProperty(PropertyName = "Keywords")]
        public string Keywords { get; }

        [JsonProperty(PropertyName = "Zipcode")]
        public string Zipcode { get; }

        [JsonProperty(PropertyName = "IsAdminApproved")]
        public string IsAdminApproved { get; }

        public ChannelRegisterRequest(ChannelRegisterItem channelRegisterItem)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            LANNAme = channelRegisterItem.LANNAme;
           // Users_ID = App.CurrentUser.User_db_Users_ID;
            Type = channelRegisterItem.Type;
            About = channelRegisterItem.About;
            Keywords = channelRegisterItem.Keywords;
            Zipcode = channelRegisterItem.ZipCode;
            IsAdminApproved = channelRegisterItem.IsAdminApproved;
        }
    }
    public class GetChannelListRequest
    {

        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "Users_ID")]
        public string Users_ID { get; }


        public GetChannelListRequest()
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            //Users_ID = App.CurrentUser.User_db_Users_ID;
        }
    }

    public class GetSubscribedChannelListRequest
    {

        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }


        public GetSubscribedChannelListRequest()
        {
            AuthorizationKey = Configuration.AuthorizationKey;
           // UserKey = App.CurrentUser.User_db_Users_ID;
        }
    }

    public class GetChannelsMainCategoryRequest
    {

        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "Type")]
        public string Type { get; }


        public GetChannelsMainCategoryRequest()
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            Type = "C";
        }
    }

    public class GetChannelsSubCategoryRequest
    {

        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "MainCategoryID")]
        public string MainCategoryID { get; }


        public GetChannelsSubCategoryRequest(string mainCategoryID)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            MainCategoryID = mainCategoryID;
        }
    }


    public class GetBusinessReviewsRequest
    {

        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "BusinessKey")]
        public string BusinessKey { get; }

        [JsonProperty(PropertyName = "Count")]
        public string Count { get; }


        public GetBusinessReviewsRequest(string businessKey, string count)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            Count = count;
            BusinessKey = businessKey;
        }
    }

    public class ReviewsSubmitRequest
    {

        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "BusinessKey")]
        public string BusinessKey { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }

        [JsonProperty(PropertyName = "Review")]
        public string Review { get; }

        [JsonProperty(PropertyName = "Points")]
        public string Points { get; }

        

        public ReviewsSubmitRequest(string businessKey, string userKey, string review, string point)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            UserKey = userKey;
            BusinessKey = businessKey;
            Review = review;
            Points = point;
        }
    }

    public class GetEventsRequest 
    {
        private string v1;
        private string user_db_Users_ID;
        private string v2;
        private string v3;
        private string user_dbZipcode;
        private string v4;
        private string v5;

        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "PageNo")]
        public string PageNo { get; }

        [JsonProperty(PropertyName = "UserKey")]
        public string UserKey { get; }

        [JsonProperty(PropertyName = "Latitude")]
        public string Latitude { get; }

        [JsonProperty(PropertyName = "Longitude")]
        public string Longitude { get; }

        [JsonProperty(PropertyName = "Zipcode")]
        public string Zipcode { get; }

        [JsonProperty(PropertyName = "Radius")]
        public string Radius { get; }

        [JsonProperty(PropertyName = "LANID")]
        public string LANID { get; }

        [JsonProperty(PropertyName = "StartDate")]
        public string StartDate { get; }

        [JsonProperty(PropertyName = "EndDate")]
        public string EndDate { get; }


        public GetEventsRequest(string pageno, string userkey, string lat, string lng, string zipcode, string radius, string lanid, string startdate, string enddate)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            PageNo = pageno;
            UserKey = userkey;
            Latitude = lat;
            Longitude = lng;
            Zipcode = zipcode;
            Radius = radius;
            LANID = lanid;
            StartDate = startdate;
            EndDate = enddate;
        }

       
    }

    public class GetUserImageRequest
    {

        [JsonProperty(PropertyName = "AuthorizationKey")]
        public string AuthorizationKey { get; }

        [JsonProperty(PropertyName = "dbUserKey")]
        public string dbUserKey { get; }


        public GetUserImageRequest(string userkey)
        {
            AuthorizationKey = Configuration.AuthorizationKey;
            dbUserKey = userkey;
        }
    }
}
