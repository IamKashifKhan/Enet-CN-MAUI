using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
 
namespace EnetCNMAUI.Models
{
    public class IsVerified
    {
        public string isVerified { get; set; }
    }
    public class IsUpdated
    {
        public string isUpdated { get; set; }
    }
    public class UserPass
    {
        public string dbUserName { get; set; }
        public string dbPassword { get; set; }

    }
    public class ActiveLanClass
    {
        public string LanID { get; set; }
        public string LanName { get; set; }
        public string StateCode { get; set; }
    }
    public class StateNameCode
    {
        public string StateName { get; set; }
        public string StateCode { get; set; }
    }
    public class LanZipCodeobj
    {
        public string LanZipCode { get; set; }
    }
   
    public class CarDetailsModel : INotifyPropertyChanged
    {

        public string BusinessKey { get; set; }
        public string BusinessName { get; set; }
        public string UserKey { get; set; }
        public string UserNickName { get; set; }
        public string UserFirstName { get; set; }
        public string dbLastName { get; set; }
        public string UserName { get; set; }
        public string FeedKey { get; set; }
        public string FeedImagePath { get; set; }
        public string BusinessLogoPath { get; set; }
        public string UserImagePath { get; set; }
        public string Subject { get; set; }
        //private string _Feed;
        public string Feed { get; set; }
        //{
        //    get { return _Feed; }
        //    set
        //    {
        //        _Feed = value;
        //        OnPropertyChanged("Feed");
        //    }
        //}
        //private double _RowHeight;
        public double RowHeight { get; set; }
        //{
        //    get { return _RowHeight; }
        //    set
        //    {
        //        RowHeight = value;
        //        OnPropertyChanged("RowHeight");
        //    }
        // }
        public string FeedLink { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Feed_Schedule_ID { get; set; }
        public string Time { get; set; }
        public string Timestamp { get; set; }
        public string Comment_FeedKey { get; set; }
        public string Comment_CommentKey { get; set; }
        public string Comment_UserKey { get; set; }
        public string Comment_Comment { get; set; }
        public string Comment_ParentCommentKey { get; set; }
        public DateTime Comment_Timestamp { get; set; }
        public string Comment_NickName { get; set; }
        public string Comment_FirstName { get; set; }
        public string Comment_LastName { get; set; }
        public string Comment_UserName { get; set; }
        public string Comment_Password { get; set; }
        public string Comment_Phone { get; set; }
        public string Comment_DOB { get; set; }
        public string Comment_Country { get; set; }
        public string Comment_City { get; set; }
        public string Comment_State { get; set; }
        public string Comment_Address { get; set; }
        public string Comment_Zipcode { get; set; }
        public string Comment_Latitude { get; set; }
        public string Comment_Longitude { get; set; }
        public string Comment_ImagePath { get; set; }
        public string Comment_CoverImagePath { get; set; }
        public string Comment_Active { get; set; }
        public string Comment_RegistrationTimestamp { get; set; }
        public string dbActive { get; set; }
        public int Emoji_0 { get; set; }
        public int Emoji_1 { get; set; }
        public int Emoji_2 { get; set; }
        public int Emoji_3 { get; set; }
        public int Emoji_4 { get; set; }
        public int Emoji_5 { get; set; }
        public int Emoji_6 { get; set; }
        public int Emoji_7 { get; set; }
        public int Emojis_Count { get; set; }
        public string TotalComments { get; set; }
        public string UserEmoji_0 { get; set; }
        public string UserEmoji_1 { get; set; }
        public string UserEmoji_2 { get; set; }
        public string UserEmoji_3 { get; set; }
        public string UserEmoji_4 { get; set; }
        public string UserEmoji_5 { get; set; }
        public string UserEmoji_6 { get; set; }
        public string UserEmoji_7 { get; set; }
        public string UserEmojis_Count { get; set; }
        public string ParentFeedUserKey { get; set; }
        public string ParentFeedUserFirstName { get; set; }
        public string ParentFeedUserLastName { get; set; }
        public string ParentFeedUserImagePath { get; set; }
        public string ParentFeed_FeedKey { get; set; }
        public string ParentFeedTimestamp { get; set; }
        public string ParentFeed_Feed { get; set; }
        public string ParentFeed_Link { get; set; }
        public string ParentFeed_ImagePath { get; set; }

        

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class ConnectionItem
    {
        public string ConnectionType { get; set; }
        public string isApproved { get; set; }
        public string Parent_db_Users_ID { get; set; }
        public string Parent_dbNickName { get; set; }
        public string Parent_dbFirstName { get; set; }
        public string Parent_dbLastName { get; set; }
        public string Parent_dbEmail { get; set; }
        public string Parent_dbPassword { get; set; }
        public string Parent_dbTempPhone { get; set; }
        public string Parent_dbPhone { get; set; }
        public string Parent_dbDoB { get; set; }
        public string Parent_dbCountry { get; set; }
        public string Parent_dbCity { get; set; }
        public string Parent_dbState { get; set; }
        public string Parent_dbAddress { get; set; }
        public string Parent_dbZipcode { get; set; }
        public string Parent_dbLatitude { get; set; }
        public string Parent_dbLongitude { get; set; }
        public string Parent_dbImagePath { get; set; }
        public string Parent_dbCoverImagePath { get; set; }
        public string Parent_dbHobby { get; set; }
        public string Parent_dbMarried { get; set; }
        public string Parent_dbAbout { get; set; }
        public string Parent_dbCompany { get; set; }
        public string Parent_dbTimestamp { get; set; }
        public string Parent_dbDeviceRegistrationToken { get; set; }
        public string Parent_dbPNSTags { get; set; }
        public string Parent_dbReferral { get; set; }
        public string Parent_dbISNonTLP { get; set; }
        public string Parent_dbVerificationCode { get; set; }
        public string Parent_dbActive { get; set; }
        public string Parent_dbisUser { get; set; }
        public string Parent_dbisBusiness { get; set; }
        public string Parent_dbisChannel { get; set; }
        public string Parent_dbTimezone { get; set; }
        public string Parent_dbisDST { get; set; }
        public string Child_db_Users_ID { get; set; }
        public string Child_dbNickName { get; set; }
        public string Child_dbFirstName { get; set; }
        public string Child_dbLastName { get; set; }
        public string Child_dbEmail { get; set; }
        public string Child_dbPassword { get; set; }
        public string Child_dbTempPhone { get; set; }
        public string Child_dbPhone { get; set; }
        public string Child_dbDoB { get; set; }
        public string Child_dbCountry { get; set; }
        public string Child_dbCity { get; set; }
        public string Child_dbState { get; set; }
        public string Child_dbAddress { get; set; }
        public string Child_dbZipcode { get; set; }
        public string Child_dbLatitude { get; set; }
        public string Child_dbLongitude { get; set; }
        public string Child_dbImagePath { get; set; }
        public string Child_dbCoverImagePath { get; set; }
        public string Child_dbHobby { get; set; }
        public string Child_dbMarried { get; set; }
        public string Child_dbAbout { get; set; }
        public string Child_dbCompany { get; set; }
        public string Child_dbTimestamp { get; set; }
        public string Child_dbDeviceRegistrationToken { get; set; }
        public string Child_dbPNSTags { get; set; }
        public string Child_dbReferral { get; set; }
        public string Child_dbISNonTLP { get; set; }
        public string Child_dbVerificationCode { get; set; }
        public string Child_dbActive { get; set; }
        public string Child_dbisUser { get; set; }
        public string Child_dbisBusiness { get; set; }
        public string Child_dbisChannel { get; set; }
        public string Child_dbTimezone { get; set; }
        public string Child_dbisDST { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    
    public class UserProfile  
    {
        
 
        public string User_dbWorkInfo { get; set; }
       

        public string User_dbGender { get; set; }
         

        public string User_db_Users_ID { get; set; }

         public string User_dbNickName { get; set; }
        

        public string User_dbFirstName { get; set; }
       
        public string User_dbLastName  { get; set; }
        


        public string User_dbEmail { get; set; }
        public string User_dbPassword { get; set; }
        public string User_dbTempPhone { get; set; }
        public string User_dbPhone { get; set; }
 

        public DateTime User_dbDoB { get; set; }
        

        public string User_dbCountry { get; set; }

 
        public string User_dbCity { get; set; }
        
 
 
        public string User_dbState { get; set; }
        
 

 
        public string User_dbAddress { get; set; }
        
 
        public string User_dbZipcode { get; set; }
        

        public string User_dbLatitude { get; set; }
        public string User_dbLongitude { get; set; }
        public string User_dbImagePath { get; set; }
        public string User_dbCoverImagePath { get; set; }

         public string User_dbHobby { get; set; }
         

         public string User_dbMarried { get; set; }
     

         public string User_dbAbout { get; set; }
       
         public string User_dbCompany { get; set; }
         
         public string User_dbTimestamp { get; set; }
        
        public string User_dbDeviceRegistrationToken { get; set; }
        public string User_dbPNSTags { get; set; }
        public string User_dbReferral { get; set; }
        public string User_dbISNonTLP { get; set; }
        public string User_dbVerificationCode { get; set; }
        public string User_dbActive { get; set; }
        public string User_dbisUser { get; set; }
        public string User_dbisBusiness { get; set; }
        public string User_dbisChannel { get; set; }
        public string User_dbTimezone { get; set; }
        public string User_dbisDST { get; set; }
        public string UserKey { get; set; }
        public string Following { get; set; }
        public string Followers { get; set; }
        public string Blocked { get; set; }
        public string FeedPosts { get; set; }

         public string User_dbHobby_Privacy { get; set; }
       
         public string User_dbMarried_Privacy { get; set; }
        

      

         public string User_dbAbout_Privacy { get; set; }
       

         public string User_dbGender_Privacy { get; set; }
         

         public string User_dbWorkInfo_Privacy { get; set; }
         

         public string User_dbCompany_Privacy { get; set; }

    }


    public class AddFeedResponse
    {
        public string Success { get; set; }
    }

    public class CheckConnectionResponse
    {
        public string isConnected { get; set; }
    }

    public class AddConnectionResponse
    {
        public string isSuccess { get; set; }
    }

    public class MessagesListItem
    {
        public string MessagingKey { get; set; }
        public string BusinessID { get; set; }
        public string MessageBody { get; set; }
        public string Subject { get; set; }
        public string CompanyLogo { get; set; }
        public string LastMessageDate { get; set; }
        public string MessagesCount { get; set; }
        public string IsRead { get; set; }
    }

    public class GroupMessagingListItem
    {
        public string ParentGroupMessageKey { get; set; }
        public string GroupMessageKey { get; set; }
        public string PersonType { get; set; }
        public string SenderKey { get; set; }
        public string SenderFirstName { get; set; }
        public string SenderLastName { get; set; }
        public string GroupTitle { get; set; }
        public string GroupMessage { get; set; }
        public string MessagePriority { get; set; }
        public string isTxt { get; set; }
        public string ImagePath { get; set; }
        public DateTime MessageTimestamp { get; set; }
        public string BusinessKey { get; set; }
        public string BusinessName { get; set; }
        public string RecipientKey { get; set; }
        public string BusinessImagePath { get; set; }
        public bool isGroup { get; set; }
        public string LastGroupMessageStatus { get; set; }


    }
    public class NotificationItem
    {
        public string NotificationKey { get; set; }
        public string SenderType { get; set; }
        public string SenderName { get; set; }
        public string Timestamp { get; set; }
        public string MessageBody { get; set; }
        public string ImagePath { get; set; }
        public string isReplyPossible { get; set; }
        public string ParentNotificationKey { get; set; }
    }

    public class MessageCountItem
    {
        public string MessagesCount { get; set; }
        public string GroupMessagesCount { get; set; }
    }


    public class MessageItem
    {
        public string RowsCount { get; set; }
        public string MessageID { get; set; }
        public string SenderID { get; set; }
        public string UserNickName { get; set; }
        public string UserImagePath { get; set; }
        public string Body { get; set; }
        public string Status { get; set; }
        public string IsTxt { get; set; }
        public string Dated { get; set; }
        public string ImagePath { get; set; }
        public string ReadStatus { get; set; }
        public string PersonType { get; set; }
    }

    public class ChannelRegisterItem
    {
        public string LANNAme { get; set; }
        public string Users_ID { get; set; }
        public string Type { get; set; }
        public string About { get; set; }
        public string Keywords { get; set; }
        public string ZipCode { get; set; }
        public string IsAdminApproved { get; set; }
     
    }

    public class ChannelRegisterResponse
    {
        public string BusinessKey { get; set; }
    }

    public class ChannelsListResponse
    {
        public string LanID { get; set; }
        public string LanName { get; set; }
        public string StateCode { get; set; }
        public string IsAdminApproved { get; set; }
        public string Logo { get; set; }
        public string StateName { get; set; }
        public string IsApproved { get; set; }
        public string dbDescription { get; set; }
        public string isPublished { get; set; }
    }

    public class SubscribedChannelsListItem
    {
        public string LanID { get; set; }
        public string LanName { get; set; }
        public string StateCode { get; set; }
        public string IsAdminApproved { get; set; }
        public string Logo { get; set; }
        public string StateName { get; set; }
        public string IsApproved { get; set; }
        public string dbDescription { get; set; }
        public string isPublished { get; set; }
    }

   
    


}