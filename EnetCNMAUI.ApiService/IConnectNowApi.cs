using EnetCNMAUI.ApiService.Requests.MVC;
using EnetCNMAUI.Requests;
using EnetCNMAUI.Requests.User;
using Refit;
using RegisterRequest = EnetCNMAUI.Requests.RegisterRequest;

namespace EnetCNMAUI.Services
{
    [Headers("Accept: application/json")]
    public interface IEnetCNMAUIApi
    {

        [Post("/api/User/registerby-email")]
        Task<HttpResponseMessage> RegisterByEmail([Body] EmailRegisterRequest request);

        [Post("/api/User/registerby-phone")]
        Task<HttpResponseMessage> RegisterByPhone([Body] PhoneRegisterRequest request);

        [Post("/api/User/registerby-auth0")]
        Task<HttpResponseMessage> RegisterByAuth0([Body] Auth0RegisterRequest request);

        [Post("/api/User/login")]
        Task<HttpResponseMessage> Login([Body] NewLoginRequest request);

        [Post("/api/User/forgot-password")]
        Task<HttpResponseMessage> forgotpassword([Body] ForgotPasswordRequest request);

        [Post("/api/User/verifyby-phone")]
        Task<HttpResponseMessage> VerifyUserByPhone([Body] UserVerificationByPhoneRequest request);

        [Post("/api/User/verifyby-email")]
        Task<HttpResponseMessage> VerifyUserByEmail([Body] UserVerificationByEmailRequest request);

        [Post("/api/User/set-password")]
        Task<HttpResponseMessage> SetPassword([Body] SetPasswordRequest request);

        [Get("/api/User/secure-data")]
        Task<HttpResponseMessage> GetSecureData();


        [Post("/Change_Password_JSON")]
        Task<HttpResponseMessage> ChangePassword([Body(BodySerializationMethod.UrlEncoded)] ChangePasswordRequest changePasswordRequest);


        
        [Post("/Get_User_by_NameSearch")]
        Task<HttpResponseMessage> SearchUser([Body(BodySerializationMethod.UrlEncoded)] SearchRequest login);

        [Post("/Register_User")]
        Task<HttpResponseMessage> RegisterUser([Body(BodySerializationMethod.UrlEncoded)] RegisterRequest registerRequest);

        [Post("/Verify_User_Code")]
        Task<HttpResponseMessage> VerifyUserCode([Body(BodySerializationMethod.UrlEncoded)] VerifyCodeRequest registerRequest);

        [Post("/Update_User")]
        Task<HttpResponseMessage> UpdateUser([Body(BodySerializationMethod.UrlEncoded)] UpadteUserRequest user);
       

        [Post("/Update_User")]
        Task<HttpResponseMessage> Update_User_Privacy([Body(BodySerializationMethod.UrlEncoded)] UpdateUserPrivacyRequestModel user);


        [Post("/Update_User")]
        Task<HttpResponseMessage> testdictionaryservice([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, string> user);

        [Post("/Get_States_With_Lan")]
        Task<HttpResponseMessage> GetStatesWithLan([Body(BodySerializationMethod.UrlEncoded)] AuthorizationKeyRequest authorizationKeyRequest);

        [Post("/Get_Lans")]
        Task<HttpResponseMessage> GetLans([Body(BodySerializationMethod.UrlEncoded)] AuthorizationKeyRequest authorizationKeyRequest);

        [Post("/Get_Zip_From_Lan")]
        Task<HttpResponseMessage> GetZipFromLan([Body(BodySerializationMethod.UrlEncoded)] GetZipFromLanRequest getZipFromLanRequest);

        [Post("/Get_Users_Feed_JSON")]
        Task<HttpResponseMessage> GetUsersFeed([Body(BodySerializationMethod.UrlEncoded)] GetUserFeedRequest getUserFeedRequest);

        [Post("/Get_User_Connections")]
        Task<HttpResponseMessage> GetUserConnections([Body(BodySerializationMethod.UrlEncoded)] GetConnectionRequest getConnectionRequest);

        [Post("/Add_User_Connections")]
        Task<HttpResponseMessage> AddRemoveConnection([Body(BodySerializationMethod.UrlEncoded)] AddRemoveConnectionRequest addRemoveConnectionRequest);

        [Post("/Search_User_JSON")]
        Task<HttpResponseMessage> SearchUsers([Body(BodySerializationMethod.UrlEncoded)] SearchConnectionRequest addRemoveConnectionRequest);

        [Post("/Get_User_byID")]
        Task<HttpResponseMessage> GetUserbyID([Body(BodySerializationMethod.UrlEncoded)] GetUserByIdRequest getUserByIdRequest);

        [Post("/Get_Feed_Comment_Comment")]
        Task<HttpResponseMessage> GetFeedComments([Body(BodySerializationMethod.UrlEncoded)] GetFeedCommentRequest getFeedCommentRequest);

        [Post("/Add_Feed_Comment_Comment")]
        Task<HttpResponseMessage> AddFeedComment([Body(BodySerializationMethod.UrlEncoded)] AddFeedCommentRequest addFeedCommentRequest);

        [Post("/Submit_Users_Feed_JSON")]
        Task<HttpResponseMessage> SubmitUsersFeed([Body(BodySerializationMethod.UrlEncoded)] UserFeedRequest addFeedCommentRequest);


        [Post("/Get_User_User_Connections")]
        Task<HttpResponseMessage> CheckUserConnection([Body(BodySerializationMethod.UrlEncoded)] CheckUserConnectionRequest userConnectionRequest);

        [Post("/AddDelete_Feed_Comment_Emoji")]
        Task<HttpResponseMessage> AddDeleteFeedCommentEmoji([Body(BodySerializationMethod.UrlEncoded)] AddDeleteFeedCommentEmojiRequest userConnectionRequest);


        [Post("/Share_Feed")]
        Task<HttpResponseMessage> ShareFeed([Body(BodySerializationMethod.UrlEncoded)] ShareFeedRequest shareFeedRequest);


        [Post("/Approve_User_Connections")]
        Task<HttpResponseMessage> ApproveUserConnections([Body(BodySerializationMethod.UrlEncoded)] ApproveUserConnectionsRequest shareFeedRequest);


        [Post("/Get_Category_Main_Sub_WITH_BUSINESS_NON0_OnlyBusiness_JSON")]
        Task<HttpResponseMessage> GetBusinessCategories([Body(BodySerializationMethod.UrlEncoded)] GetBusinessCategoriesRequest shareFeedRequest);

        [Post("/Delete_Feed")]
        Task<HttpResponseMessage> DeleteFeed([Body(BodySerializationMethod.UrlEncoded)] DeleteFeedRequest shareFeedRequest);

        [Post("/Edit_Users_Feed_JSON")]
        Task<HttpResponseMessage> EditFeed([Body(BodySerializationMethod.UrlEncoded)] EditFeedRequest shareFeedRequest);


        [Post("/GetUserMessageList")]
        Task<HttpResponseMessage> GetUserMessageList([Body(BodySerializationMethod.UrlEncoded)] GetMessageListRequest getMessageListRequest);


        [Post("/Get_User_Channel_Groups")]
        Task<HttpResponseMessage> Get_User_Channel_Groups([Body(BodySerializationMethod.UrlEncoded)] GetMessageListRequest getMessageListRequest);

        

        [Post("/GetNotifications")]
        Task<HttpResponseMessage> GetNotifications([Body(BodySerializationMethod.UrlEncoded)] GetMessageListRequest getMessageListRequest);

        [Post("/UnreadMessagesCount")]
        Task<HttpResponseMessage> GetUnreadMessagesCount([Body(BodySerializationMethod.UrlEncoded)] GetMessageListRequest getMessageListRequest);

        [Post("/GetMessagesBy_Key_Direction_Count")]
        Task<HttpResponseMessage> GetMessages([Body(BodySerializationMethod.UrlEncoded)] GetMessagesRequest getMessagesRequest);

        [Post("/ReplyMessage")]
        Task<HttpResponseMessage> ReplyMessage([Body(BodySerializationMethod.UrlEncoded)] SendMessageRequest sendMessageRequest);


        [Post("/Get_Feed_Active_LANID_MultiDate_Paging_JSON")]
        Task<HttpResponseMessage> GetBusinessesFeed([Body(BodySerializationMethod.UrlEncoded)] GetBusinessFeedRequest getBusinessFeedRequest);


        [Post("/Get_Feed_Active_LANID_MultiDate_Paging_JSON_NEW")]
        Task<HttpResponseMessage> GetBusinessesFeedNEW([Body(BodySerializationMethod.UrlEncoded)] GetBusinessFeedRequest getBusinessFeedRequest);


        [Post("/Get_Featured_Business_List_Active_ZipCode_Category_SUB_SPONSORS_Paging_JSON")]
        Task<HttpResponseMessage> GetBusinessesesList([Body(BodySerializationMethod.UrlEncoded)] GetBusinessListRequest getBusinessFeedRequest);


        [Post("/Get_Business_List_Active_ZipCode_Category_Paging_JSON")]
        Task<HttpResponseMessage> GetBusinessesesListForMore([Body(BodySerializationMethod.UrlEncoded)] GetBusinessListRequest getBusinessFeedRequest);




        [Post("/Get_Offers_Active_Zipcode_Favorite_Detail_Paging_JSON")]
        Task<HttpResponseMessage> GetOffersList([Body(BodySerializationMethod.UrlEncoded)] GetOffersListRequest getBusinessFeedRequest);

        [Post("/Register_LANChannels")]
        Task<HttpResponseMessage> RegisterChannel([Body(BodySerializationMethod.UrlEncoded)] ChannelRegisterRequest channelRegisterRequest);


        [Post("/GetUsers_LANChannels")]
        Task<HttpResponseMessage> GetUsersLANChannels([Body(BodySerializationMethod.UrlEncoded)] GetChannelListRequest getChannelListRequest);



        [Post("/Get_Category_Main_Sub_ALL_JSON")]
        Task<HttpResponseMessage> GetAllCategories([Body(BodySerializationMethod.UrlEncoded)] AuthorizationKeyRequest authorizationKeyRequest);


        

        [Post("/Get_AllLANChannelsUserSubscribed")]
        Task<HttpResponseMessage> GetUsersSubscribedChannels([Body(BodySerializationMethod.UrlEncoded)] GetSubscribedChannelListRequest getSubscribedChannelListRequest);



        [Post("/GetMainCategories")]
        Task<HttpResponseMessage> GetChannelsMainCategories([Body(BodySerializationMethod.UrlEncoded)] GetChannelsMainCategoryRequest getChannelsMainCategoryRequest);

        [Post("/GetSubCategories")]
        Task<HttpResponseMessage> GetChannelsSubCategories([Body(BodySerializationMethod.UrlEncoded)] GetChannelsSubCategoryRequest getChannelsSubCategoryRequest);


        //Business Details

        [Post("/Get_Business_Detail_Basic_JSON")]
        Task<HttpResponseMessage> Get_Business_Detail_Basic_JSON([Body(BodySerializationMethod.UrlEncoded)] BusinessBasicDetailsRequest businessBasicDetailsRequest);

        [Post("/Get_Geo_From_Zip")]
        Task<HttpResponseMessage> Get_Geo_From_Zip([Body(BodySerializationMethod.UrlEncoded)] BusinessLocationRequest businessLocationRequest);

        [Post("/Get_Business_Images_Active_JSON")]
        Task<HttpResponseMessage> Get_Business_Images_Active_JSON([Body(BodySerializationMethod.UrlEncoded)] BusinessBasicDetailsRequest businessBasicDetailsRequest);

        [Post("/Get_Business_Schedule_JSON")]
        Task<HttpResponseMessage> Get_Business_Schedule_JSON([Body(BodySerializationMethod.UrlEncoded)] BusinessBasicDetailsRequest businessBasicDetailsRequest);

        [Post("/Get_Business_Offers_Active_JSON")]
        Task<HttpResponseMessage> Get_Business_Offers_Active_JSON([Body(BodySerializationMethod.UrlEncoded)] BusinessBasicDetailsRequest businessBasicDetailsRequest);

        [Post("/Get_Business_SocialLinks_JSON_List")]
        Task<HttpResponseMessage> Get_Business_SocialLinks_JSON([Body(BodySerializationMethod.UrlEncoded)] BusinessBasicDetailsRequest businessBasicDetailsRequest);



        //Update user

        [Post("/Update_User_JSON")]
        Task<HttpResponseMessage> Update_User_JSON([Body(BodySerializationMethod.UrlEncoded)] UpdateUserCoverImageRequest updateUserRequest);


        [Post("/Get_Business_Reviews_Limited_JSON")]
        Task<HttpResponseMessage> GetBusinessReviews([Body(BodySerializationMethod.UrlEncoded)] GetBusinessReviewsRequest businessReviewsRequest);


        [Post("/Get_Business_Reviews_Summary_JSON")]
        Task<HttpResponseMessage> GetBusinessReviewsSummary([Body(BodySerializationMethod.UrlEncoded)] GetBusinessReviewsRequest businessReviewsRequest);



        [Post("/Get_Events_Active_Favorite_Paging_JSON")]
        Task<HttpResponseMessage> GetEventsActiveWithFavorite([Body(BodySerializationMethod.UrlEncoded)] GetEventsRequest getEventsRequest);


        [Post("/Add_Business_Review_Form_JSON")]
        Task<HttpResponseMessage> SubmitReview([Body(BodySerializationMethod.UrlEncoded)] ReviewsSubmitRequest reviewsSubmitRequest);



        [Post("/UserMedia")]
        Task<HttpResponseMessage> GetUserImages([Body(BodySerializationMethod.UrlEncoded)] GetUserImageRequest getUserImageRequest);

        [Post("/App_Events")]
        Task<HttpResponseMessage> GetEvents([Body(BodySerializationMethod.UrlEncoded)] EventRequest setUserPasswordRequest);


        [Post("/AppSubCategories_Detail")]
        Task<HttpResponseMessage> GetAppMainCategories([Body(BodySerializationMethod.UrlEncoded)] CategoryRequest categoryRequest);

    }
}