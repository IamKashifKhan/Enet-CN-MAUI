using EnetCNMAUI.ApiService.Requests.MVC;
using EnetCNMAUI.Domain.Models.MVC;
using EnetCNMAUI.Models;
using EnetCNMAUI.Requests;
using EnetCNMAUI.Requests.User;
using Refit;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EnetCNMAUI.Services
{
    [Headers("Accept: application/json")]

    public interface IApiService
    {

        Task<ApiResult<List<CategoryItem>>> GetAppMainCategories(CategoryRequest categoryRequest);

        Task<ApiResult<UserModel>> Login(NewLoginRequest request);

        Task<ApiResult<object>> RegisterByEmail(EmailRegisterRequest request);

        Task<ApiResult<object>> RegisterByPhone(PhoneRegisterRequest request);

        Task<ApiResult<UserModel>> RegisterByAuth0(Auth0RegisterRequest request);

        Task<ApiResult<UserModel>> VerifyUserByPhone(UserVerificationByPhoneRequest request);

        Task<ApiResult<UserModel>> VerifyUserByEmail(UserVerificationByEmailRequest request);

        Task<ApiResult<object>> SetPassword(SetPasswordRequest request);

        Task<ApiResult<object>> forgotpassword(ForgotPasswordRequest request);


        Task<ApiResult<object>> GetSecureData();

        Task<ApiResult<AddFeedResponse>> ChangePassword(ChangePasswordRequest loginRequest);

       // Task<ApiResult<List<Usernew>>> UserSearch(Credentials credentials);

        
        Task<ApiResult<IsUpdated>> UpdateUser(UpadteUserRequest user);

        Task<ApiResult<List<StateNameCode>>> GetStatesWithLan();

        Task<ApiResult<List<ActiveLanClass>>> GetLans();

        Task<ApiResult<LanZipCodeobj>> GetZipFromLan(GetZipFromLanRequest getZipFromLanRequest);

        Task<ApiResult<List<SocialFeedItem>>> GetUsersFeed(GetUserFeedRequest getUserFeedRequest);

        Task<ApiResult<List<ConnectionItem>>> GetUserConnections(GetConnectionRequest getConnectionRequest);

        Task<ApiResult<AddConnectionResponse>> AddRemoveConnection(AddRemoveConnectionRequest addRemoveConnectionRequest);

        Task<ApiResult<List<SearchConnectionItem>>> SearchUsers(SearchConnectionRequest searchConnectionRequest);

        Task<ApiResult<UserProfile>> GetUserbyID(GetUserByIdRequest getUserByIdRequest);

        Task<ApiResult<List<CommentItem>>> GetFeedComments(GetFeedCommentRequest getUserByIdRequest);

        Task<ApiResult<AddFeedResponse>> AddFeedComments(AddFeedCommentRequest getUserByIdRequest);

        Task<ApiResult<SocialFeedItem>> SubmitUsersFeed(UserFeedRequest getUserByIdRequest);

        Task<ApiResult<CheckConnectionResponse>> CheckUserConnection(CheckUserConnectionRequest getUserByIdRequest);

        Task<ApiResult<AddFeedResponse>> AddDeleteFeedCommentEmoji(AddDeleteFeedCommentEmojiRequest addDeleteFeedCommentEmojiRequest);

        Task<ApiResult<string>> ShareFeed(ShareFeedRequest shareFeedRequest);

        Task<ApiResult<AddConnectionResponse>> ApproveUserConnections(ApproveUserConnectionsRequest approveUserConnectionsRequest);

        Task<ApiResult<List<AllBusinessCategories>>> GetBusinessCategories(GetBusinessCategoriesRequest getBusinessCategoruRequest);

        Task<ApiResult<string>> DeleteFeed(DeleteFeedRequest deleteFeedRequest);

        Task<ApiResult<string>> EditFeed(EditFeedRequest editFeedRequest);

        Task<ApiResult<List<MessagesListItem>>> GetUserMessageList(GetMessageListRequest getMessageListRequest);

        Task<ApiResult<List<GroupMessagingListItem>>> Get_User_Channel_Groups(GetMessageListRequest getMessageListRequest);

        Task<ApiResult<List<NotificationItem>>> GetNotifications(GetMessageListRequest getMessageListRequest);

        Task<ApiResult<MessageCountItem>> GetUnreadMessagesCount(GetMessageListRequest getMessageListRequest);

        Task<ApiResult<List<MessageItem>>> GetMessages(GetMessagesRequest getMessagesRequest);

        Task<ApiResult<MessageItem>> ReplyMessage(SendMessageRequest sendMessageRequest);

        Task<ApiResult<List<BusinessFeedItem>>> GetBusinessesFeed(GetBusinessFeedRequest getBusinessFeedRequest);

        Task<ApiResult<List<SocialFeedItem>>> GetBusinessesFeedNEW(GetBusinessFeedRequest getBusinessFeedRequest);

        Task<ApiResult<List<BusinessListItem>>> GetBusinessesList(GetBusinessListRequest getBusinessListRequest);

        Task<ApiResult<List<BusinessListItem>>> GetBusinessesListForMore(GetBusinessListRequest getBusinessListRequest);

        Task<ApiResult<List<OffersListItem>>> GetOffersList(GetOffersListRequest getOffersListRequest);

        Task<ApiResult<ChannelRegisterResponse>> RegisterChannel(ChannelRegisterRequest getOffersListRequest);

        Task<ApiResult<List<ChannelsListResponse>>> GetUsersLANChannels(GetChannelListRequest getChannelListRequest);

        Task<ApiResult<List<CatergoryList>>> GetAllCategories(AuthorizationKeyRequest authorizationKeyRequest);

        Task<ApiResult<List<SubscribedChannelsListItem>>> GetUsersSubscribedChannels(GetSubscribedChannelListRequest subscribedChannelListRequest);

        Task<ApiResult<List<CatergoryList>>> GetChannelsMainCategories(GetChannelsMainCategoryRequest getChannelsMainCategoryRequest);

        Task<ApiResult<List<SubCatergoryList>>> GetChannelsSubCategories(GetChannelsSubCategoryRequest getChannelsSubCategoryRequest);


        //Business Details

        Task<ApiResult<BusinessBasicDetailItem>> Get_Business_Detail_Basic_JSON(BusinessBasicDetailsRequest businessBasicDetailsRequest);

        Task<ApiResult<ZipCodetoLocationItem>> Get_Geo_From_Zip(BusinessLocationRequest businessLocationRequest);

        Task<ApiResult<List<BusinessImagesItem>>> Get_Business_Images_Active_JSON(BusinessBasicDetailsRequest getChannelsSubCategoryRequest);

        Task<ApiResult<BusinessScheduleItem>> Get_Business_Schedule_JSON(BusinessBasicDetailsRequest businessLocationRequest);

        Task<ApiResult<List<BusinessOffersItem>>> Get_Business_Offers_Active_JSON(BusinessBasicDetailsRequest getChannelsSubCategoryRequest);

        Task<ApiResult<List<BusinessSocialItem>>> Get_Business_SocialLinks_JSON(BusinessBasicDetailsRequest getChannelsSubCategoryRequest);


        //      Task<ApiResult<IsUpdated>> testdictionaryservice(IDictionary<string, string> user);


        Task<ApiResult<UpdateUserModel>> Update_User_JSON(UpdateUserCoverImageRequest updateUserCoverImageRequest);

        Task<ApiResult<string>> Update_User_Privacy(UpdateUserPrivacyRequestModel userPrivacyRequestModel);


        Task<ApiResult<List<BusinessReviews>>> GetBusinessReviews(GetBusinessReviewsRequest businessReviewsRequest);

        Task<ApiResult<List<BusinessReviewsSummary>>> GetBusinessReviewsSummary(GetBusinessReviewsRequest businessReviewsRequest);

        Task<ApiResult<List<EventItem>>> GetEventsActiveWithFavorite(GetEventsRequest businessReviewsRequest);

        Task<ApiResult<StatusItem>> SubmitReview(ReviewsSubmitRequest businessReviewsRequest);

        Task<ApiResult<List<UserImagesItem>>> GetUserImages(GetUserImageRequest businessReviewsRequest);
        Task<ApiResult<List<EventItem>>> GetEvents(EventRequest eventRequest);


    }
} 
