using ConnectNow.Services;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using ConnectNow.Requests;
using ConnectNow.Models;
using ConnectNow.Helpers.Extensions;
using System.Threading;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using ConnectNow.Domain.Models;
using ConnectNow.Requests.User;
using ConnectNow.Domain.Models.MVC;
using ConnectNow.ApiService.Requests.MVC;


namespace ConnectNow.Services
{
    public class ApiService : IApiService
    {
        private IConnectNowApi ConnectNowApi { get; set; }
        private HttpClient HttpClientInstance { get; set; }
        public ApiService()

        {
            HttpClientInstance = new HttpClient(new AuthenticatedHttpClientHandler()) { BaseAddress = new Uri(Configuration.ServiceBaseUrl) };
            try
            {
                ConnectNowApi = RestService.For<IConnectNowApi>(HttpClientInstance);
            }
            catch (Exception ex)
            {

            }
        }

        public Task<string> GetPost()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ApiResult<List<CategoryItem>>> GetAppMainCategories(CategoryRequest res)
        {
            ApiResult<List<CategoryItem>> result;

            try
            {
                var response = await ConnectNowApi.GetAppMainCategories(res);
                result = await response.ToServiceResult<List<CategoryItem>>();
            }
            catch (Exception ex)
            {
                result = new ApiResult<List<CategoryItem>>(false, $"Getting AppMainCategories failed, {ex.Message}.", null);
            }

            return result;
        }
        public async Task<ApiResult<UserModel>> Login(NewLoginRequest loginRequest)
        {
            ApiResult<UserModel> result;

            try
            {
                var response = await ConnectNowApi.Login(loginRequest);
                result = await response.ToServiceResult<UserModel>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.GetType().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<UserModel>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }
        public async Task<ApiResult<object>> RegisterByEmail(EmailRegisterRequest request)
        {
            try
            {
                var response = await ConnectNowApi.RegisterByEmail(request);
                return await response.ToServiceResult<object>();
            }
            catch (Exception ex)
            {
                return new ApiResult<object>(false, $"Registration failed, {ex.Message}.", null);
            }
        }

        public async Task<ApiResult<object>> RegisterByPhone(PhoneRegisterRequest request)
        {
            try
            {
                var response = await ConnectNowApi.RegisterByPhone(request);
                return await response.ToServiceResult<object>();
            }
            catch (Exception ex)
            {
                return new ApiResult<object>(false, $"Registration failed, {ex.Message}.", null);
            }
        }

        public async Task<ApiResult<UserModel>> RegisterByAuth0(Auth0RegisterRequest request)
        {
            try
            {
                var response = await ConnectNowApi.RegisterByAuth0(request);
                return await response.ToServiceResult<UserModel>();
            }
            catch (Exception ex)
            {
                return new ApiResult<UserModel>(false, $"Registration with Auth0 failed, {ex.Message}.", null);
            }
        }

        

        public async Task<ApiResult<UserModel>> VerifyUserByPhone(UserVerificationByPhoneRequest request)
        {
            try
            {
                var response = await ConnectNowApi.VerifyUserByPhone(request);
                return await response.ToServiceResult<UserModel>();
            }
            catch (Exception ex)
            {
                return new ApiResult<UserModel>(false, $"Phone verification failed, {ex.Message}.", null);
            }
        }

        public async Task<ApiResult<UserModel>> VerifyUserByEmail(UserVerificationByEmailRequest request)
        {
            try
            {
                var response = await ConnectNowApi.VerifyUserByEmail(request);
                return await response.ToServiceResult<UserModel>();
            }
            catch (Exception ex)
            {
                return new ApiResult<UserModel>(false, $"Email verification failed, {ex.Message}.", null);
            }
        }

        public async Task<ApiResult<object>> forgotpassword(ForgotPasswordRequest request)
        {
            try
            {
                var response = await ConnectNowApi.forgotpassword(request);
                return await response.ToServiceResult<object>();
            }
            catch (Exception ex)
            {
                return new ApiResult<object>(false, $"forgot password request failed, {ex.Message}.", null);
            }
        }

        public async Task<ApiResult<object>> SetPassword(SetPasswordRequest request)
        {
            try
            {
                var response = await ConnectNowApi.SetPassword(request);
                return await response.ToServiceResult<object>();
            }
            catch (Exception ex)
            {
                return new ApiResult<object>(false, $"Password update failed, {ex.Message}.", null);
            }
        }

        public async Task<ApiResult<object>> GetSecureData()
        {
            try
            {
                var response = await ConnectNowApi.GetSecureData();
                return await response.ToServiceResult<object>();
            }
            catch (Exception ex)
            {
                return new ApiResult<object>(false, $"Fetching secure data failed, {ex.Message}.", null);
            }
        }

        public async Task<ApiResult<AddFeedResponse>> ChangePassword(ChangePasswordRequest changePassword)
        {
            ApiResult<AddFeedResponse> result;

            try
            {
                var response = await ConnectNowApi.ChangePassword(changePassword);
                result = await response.ToServiceResult<AddFeedResponse>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<AddFeedResponse>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }
 
 

        public async Task<ApiResult<IsUpdated>> UpdateUser(UpadteUserRequest userrequest)
        {
            ApiResult<IsUpdated> result;

            try
            {
                var response = await ConnectNowApi.UpdateUser(userrequest);
                result = await response.ToServiceResult<IsUpdated>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.GetType().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<IsUpdated>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<List<StateNameCode>>> GetStatesWithLan()
        {
            ApiResult<List<StateNameCode>> result;

            try
            {
                AuthorizationKeyRequest authorizationKeyRequest = new AuthorizationKeyRequest();
                var response = await ConnectNowApi.GetStatesWithLan(authorizationKeyRequest);
                result = await response.ToServiceResult<List<StateNameCode>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.GetType().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<StateNameCode>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }
        public async Task<ApiResult<List<ActiveLanClass>>> GetLans()
        {
            ApiResult<List<ActiveLanClass>> result;
            try
            {
                AuthorizationKeyRequest authorizationKeyRequest = new AuthorizationKeyRequest();
                var response = await ConnectNowApi.GetLans(authorizationKeyRequest);
                result = await response.ToServiceResult<List<ActiveLanClass>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.GetType().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<ActiveLanClass>>(false, $"Authentication failed, {ex.Message}.", null);
            }
            return result;
        }
        public async Task<ApiResult<LanZipCodeobj>> GetZipFromLan(GetZipFromLanRequest getZipFromLanRequest)
        {
            ApiResult<LanZipCodeobj> result;

            try
            {
                var response = await ConnectNowApi.GetZipFromLan(getZipFromLanRequest);
                result = await response.ToServiceResult<LanZipCodeobj>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<LanZipCodeobj>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<List<SocialFeedItem>>> GetUsersFeed(GetUserFeedRequest getUserFeedRequest)
        {
            ApiResult<List<SocialFeedItem>> result;

            try
            {
                var response = await ConnectNowApi.GetUsersFeed(getUserFeedRequest);
                result = await response.ToServiceResult<List<SocialFeedItem>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<SocialFeedItem>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<List<ConnectionItem>>> GetUserConnections(GetConnectionRequest getConnectionRequest)
        {
            ApiResult<List<ConnectionItem>> result;

            try
            {
                var response = await ConnectNowApi.GetUserConnections(getConnectionRequest);
                result = await response.ToServiceResult<List<ConnectionItem>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<ConnectionItem>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<AddConnectionResponse>> AddRemoveConnection(AddRemoveConnectionRequest addRemoveConnectionRequest)
        {
            ApiResult<AddConnectionResponse> result;

            try
            {
                var response = await ConnectNowApi.AddRemoveConnection(addRemoveConnectionRequest);
                result = await response.ToServiceResult<AddConnectionResponse>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<AddConnectionResponse>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }
        public async Task<ApiResult<List<SearchConnectionItem>>> SearchUsers(SearchConnectionRequest searchConnectionRequest)
        {
            ApiResult<List<SearchConnectionItem>> result;

            try
            {
                var response = await ConnectNowApi.SearchUsers(searchConnectionRequest);
                result = await response.ToServiceResult<List<SearchConnectionItem>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<SearchConnectionItem>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }
        public async Task<ApiResult<UserProfile>> GetUserbyID(GetUserByIdRequest getUserByIdRequest)
        {
            ApiResult<UserProfile> result;

            try
            {
                var response = await ConnectNowApi.GetUserbyID(getUserByIdRequest);
                result = await response.ToServiceResult<UserProfile>();

            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<UserProfile> (false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }
        public async Task<ApiResult<List<CommentItem>>> GetFeedComments(GetFeedCommentRequest getFeedCommentRequest)
        {
            ApiResult<List<CommentItem>> result;

            try
            {
                var response = await ConnectNowApi.GetFeedComments(getFeedCommentRequest);
                result = await response.ToServiceResult<List<CommentItem>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<CommentItem>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<AddFeedResponse>> AddFeedComments(AddFeedCommentRequest addFeedCommentRequest)
        {
            ApiResult<AddFeedResponse> result;

            try
            {
                var response = await ConnectNowApi.AddFeedComment(addFeedCommentRequest);
                result = await response.ToServiceResult<AddFeedResponse>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<AddFeedResponse>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<SocialFeedItem>> SubmitUsersFeed(UserFeedRequest userFeedRequest)
        {
            ApiResult<SocialFeedItem> result;

            try
            {
                var response = await ConnectNowApi.SubmitUsersFeed(userFeedRequest);
                result = await response.ToServiceResult<SocialFeedItem>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<SocialFeedItem>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<CheckConnectionResponse>> CheckUserConnection(CheckUserConnectionRequest userConnection)
        {
            ApiResult<CheckConnectionResponse> result;

            try
            {
                var response = await ConnectNowApi.CheckUserConnection(userConnection);
                result = await response.ToServiceResult<CheckConnectionResponse>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<CheckConnectionResponse>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<AddFeedResponse>> AddDeleteFeedCommentEmoji(AddDeleteFeedCommentEmojiRequest addDeleteFeedCommentEmojiRequest)
        {
            ApiResult<AddFeedResponse> result;

            try
            {
                var response = await ConnectNowApi.AddDeleteFeedCommentEmoji(addDeleteFeedCommentEmojiRequest);
                result = await response.ToServiceResult<AddFeedResponse>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<AddFeedResponse>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }
        public async Task<ApiResult<string>> ShareFeed(ShareFeedRequest shareFeedRequest)
        {
            ApiResult<string> result;

            try
            {
                var response = await ConnectNowApi.ShareFeed(shareFeedRequest);
                result = await response.ToServiceResult<string>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<string>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<AddConnectionResponse>> ApproveUserConnections(ApproveUserConnectionsRequest approveUserConnectionsRequest)
        {
            ApiResult<AddConnectionResponse> result;

            try
            {
                var response = await ConnectNowApi.ApproveUserConnections(approveUserConnectionsRequest);
                result = await response.ToServiceResult<AddConnectionResponse>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<AddConnectionResponse>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<List<AllBusinessCategories>>> GetBusinessCategories(GetBusinessCategoriesRequest getBusinessCategoriesRequest)
        {
            ApiResult<List<AllBusinessCategories>> result;

            try
            {
                var response = await ConnectNowApi.GetBusinessCategories(getBusinessCategoriesRequest);
                result = await response.ToServiceResult<List<AllBusinessCategories>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<AllBusinessCategories>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }
        public async Task<ApiResult<string>> DeleteFeed(DeleteFeedRequest deleteFeedRequest)
        {
            ApiResult<string> result;

            try
            {
                var response = await ConnectNowApi.DeleteFeed(deleteFeedRequest);
                result = await response.ToServiceResult<string>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<string>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        //edit  social feed 
        public async Task<ApiResult<string>> EditFeed(EditFeedRequest editFeedRequest)
        {
            ApiResult<string> result;

            try
            {
                var response = await ConnectNowApi.EditFeed(editFeedRequest);
                result = await response.ToServiceResult<string>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<string>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        //get user messages list 
        public async Task<ApiResult<List<MessagesListItem>>> GetUserMessageList(GetMessageListRequest getMessageListRequest)
        {
            ApiResult<List<MessagesListItem>> result;

            try
            {
                var response = await ConnectNowApi.GetUserMessageList(getMessageListRequest);
                result = await response.ToServiceResult<List<MessagesListItem>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<MessagesListItem>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        //get user group message messages list 
        public async Task<ApiResult<List<GroupMessagingListItem>>> Get_User_Channel_Groups(GetMessageListRequest getMessageListRequest)
        {
            ApiResult<List<GroupMessagingListItem>> result;

            try
            {
                var response = await ConnectNowApi.Get_User_Channel_Groups(getMessageListRequest);
                result = await response.ToServiceResult<List<GroupMessagingListItem>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<GroupMessagingListItem>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        

        public async Task<ApiResult<List<NotificationItem>>> GetNotifications(GetMessageListRequest getMessageListRequest)
        {
            ApiResult<List<NotificationItem>> result;

            try
            {
                var response = await ConnectNowApi.GetNotifications(getMessageListRequest);
                result = await response.ToServiceResult<List<NotificationItem>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<NotificationItem>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<MessageCountItem>> GetUnreadMessagesCount(GetMessageListRequest getMessageListRequest)
        {
            ApiResult<MessageCountItem> result;

            try
            {
                var response = await ConnectNowApi.GetUnreadMessagesCount(getMessageListRequest);
                result = await response.ToServiceResult<MessageCountItem>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<MessageCountItem>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<List<MessageItem>>> GetMessages(GetMessagesRequest getMessagesRequest)
        {
            ApiResult<List<MessageItem>> result;

            try
            {
                var response = await ConnectNowApi.GetMessages(getMessagesRequest);
                result = await response.ToServiceResult<List<MessageItem>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<MessageItem>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<MessageItem>> ReplyMessage(SendMessageRequest sendMessageRequest)
        {
            ApiResult<MessageItem> result;

            try
            {
                var response = await ConnectNowApi.ReplyMessage(sendMessageRequest);
                result = await response.ToServiceResult<MessageItem>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<MessageItem>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<List<BusinessFeedItem>>> GetBusinessesFeed(GetBusinessFeedRequest getBusinessFeedRequest)
        {

            ApiResult<List<BusinessFeedItem>> result;

            try
            {
                var response = await ConnectNowApi.GetBusinessesFeed(getBusinessFeedRequest);
                result = await response.ToServiceResult<List<BusinessFeedItem>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<BusinessFeedItem>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<List<SocialFeedItem>>> GetBusinessesFeedNEW(GetBusinessFeedRequest getBusinessFeedRequest)
        {

            ApiResult<List<SocialFeedItem>> result;

            try
            {
                var response = await ConnectNowApi.GetBusinessesFeedNEW(getBusinessFeedRequest);
                result = await response.ToServiceResult<List<SocialFeedItem>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<SocialFeedItem>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<List<BusinessListItem>>> GetBusinessesList(GetBusinessListRequest getBusinessFeedRequest)
        {
            ApiResult<List<BusinessListItem>> result;

            try
            {
                var response = await ConnectNowApi.GetBusinessesesList(getBusinessFeedRequest);
                result = await response.ToServiceResult<List<BusinessListItem>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<BusinessListItem>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<List<BusinessListItem>>> GetBusinessesListForMore(GetBusinessListRequest getBusinessFeedRequest)
        {
            ApiResult<List<BusinessListItem>> result;

            try
            {
                var response = await ConnectNowApi.GetBusinessesesList(getBusinessFeedRequest);
                result = await response.ToServiceResult<List<BusinessListItem>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<BusinessListItem>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }


        public async Task<ApiResult<List<OffersListItem>>> GetOffersList(GetOffersListRequest getBusinessFeedRequest)
        {
            ApiResult<List<OffersListItem>> result;

            try
            {
                var response = await ConnectNowApi.GetOffersList(getBusinessFeedRequest);
                result = await response.ToServiceResult<List<OffersListItem>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<OffersListItem>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<ChannelRegisterResponse>> RegisterChannel(ChannelRegisterRequest channelRegisterRequest)
        {
            ApiResult<ChannelRegisterResponse> result;

            try
            {
                var response = await ConnectNowApi.RegisterChannel(channelRegisterRequest);
                result = await response.ToServiceResult<ChannelRegisterResponse>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<ChannelRegisterResponse>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<List<ChannelsListResponse>>> GetUsersLANChannels(GetChannelListRequest getChannelListRequest)
        {
            ApiResult<List<ChannelsListResponse>> result;

            try
            {
                var response = await ConnectNowApi.GetUsersLANChannels(getChannelListRequest);
                result = await response.ToServiceResult<List<ChannelsListResponse>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<ChannelsListResponse>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<List<CatergoryList>>> GetAllCategories(AuthorizationKeyRequest authorizationKeyRequest)
        {
            ApiResult<List<CatergoryList>> result;

            try
            {
                var response = await ConnectNowApi.GetAllCategories(authorizationKeyRequest);
                result = await response.ToServiceResult<List<CatergoryList>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<CatergoryList>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async  Task<ApiResult<List<SubscribedChannelsListItem>>> GetUsersSubscribedChannels(GetSubscribedChannelListRequest subscribedChannelListRequest)
        {
            ApiResult<List<SubscribedChannelsListItem>> result;

            try
            {
                var response = await ConnectNowApi.GetUsersSubscribedChannels(subscribedChannelListRequest);
                result = await response.ToServiceResult<List<SubscribedChannelsListItem>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<SubscribedChannelsListItem>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<List<CatergoryList>>> GetChannelsMainCategories(GetChannelsMainCategoryRequest getChannelsMainCategoryRequest)
        {
            ApiResult<List<CatergoryList>> result;

            try
            {
                var response = await ConnectNowApi.GetChannelsMainCategories(getChannelsMainCategoryRequest);
                result = await response.ToServiceResult<List<CatergoryList>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<CatergoryList>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async  Task<ApiResult<List<SubCatergoryList>>> GetChannelsSubCategories(GetChannelsSubCategoryRequest getChannelsSubCategoryRequest)
        {
            ApiResult<List<SubCatergoryList>> result;

            try
            {
                var response = await ConnectNowApi.GetChannelsSubCategories(getChannelsSubCategoryRequest);
                result = await response.ToServiceResult<List<SubCatergoryList>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<SubCatergoryList>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<BusinessBasicDetailItem>> Get_Business_Detail_Basic_JSON(BusinessBasicDetailsRequest businessBasicDetailsRequest)
        {
            ApiResult<BusinessBasicDetailItem> result;

            try
            {
                var response = await ConnectNowApi.Get_Business_Detail_Basic_JSON(businessBasicDetailsRequest);
                result = await response.ToServiceResult<BusinessBasicDetailItem>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<BusinessBasicDetailItem>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<ZipCodetoLocationItem>> Get_Geo_From_Zip(BusinessLocationRequest businessLocationRequest)
        {
            ApiResult<ZipCodetoLocationItem> result;

            try
            {
                var response = await ConnectNowApi.Get_Geo_From_Zip(businessLocationRequest);
                result = await response.ToServiceResult<ZipCodetoLocationItem>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<ZipCodetoLocationItem>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<BusinessScheduleItem>> Get_Business_Schedule_JSON(BusinessBasicDetailsRequest businessBasicDetailsRequest)
        {
            ApiResult<BusinessScheduleItem> result;

            try
            {
                var response = await ConnectNowApi.Get_Business_Schedule_JSON(businessBasicDetailsRequest);
                result = await response.ToServiceResult<BusinessScheduleItem>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<BusinessScheduleItem>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<List<BusinessImagesItem>>> Get_Business_Images_Active_JSON(BusinessBasicDetailsRequest businessBasicDetailsRequest)
        {
            ApiResult<List<BusinessImagesItem>> result;

            try
            {
                var response = await ConnectNowApi.Get_Business_Images_Active_JSON(businessBasicDetailsRequest);
                result = await response.ToServiceResult<List<BusinessImagesItem>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<BusinessImagesItem>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<List<BusinessOffersItem>>> Get_Business_Offers_Active_JSON(BusinessBasicDetailsRequest businessBasicDetailsRequest)
        {
            ApiResult<List<BusinessOffersItem>> result;

            try
            {
                var response = await ConnectNowApi.Get_Business_Offers_Active_JSON(businessBasicDetailsRequest);
                result = await response.ToServiceResult<List<BusinessOffersItem>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<BusinessOffersItem>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<List<BusinessSocialItem>>> Get_Business_SocialLinks_JSON(BusinessBasicDetailsRequest businessBasicDetailsRequest)
        {
            ApiResult<List<BusinessSocialItem>> result;

            try
            {
                var response = await ConnectNowApi.Get_Business_SocialLinks_JSON(businessBasicDetailsRequest);
                result = await response.ToServiceResult<List<BusinessSocialItem>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<BusinessSocialItem>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<UpdateUserModel>> Update_User_JSON(UpdateUserCoverImageRequest upadteUserRequest)
        {
            ApiResult<UpdateUserModel> result;

            try
            {
                var response = await ConnectNowApi.Update_User_JSON(upadteUserRequest);
                result = await response.ToServiceResult<UpdateUserModel>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<UpdateUserModel>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<List<BusinessReviews>>> GetBusinessReviews(GetBusinessReviewsRequest businessReviewsRequest)
        {
            ApiResult<List<BusinessReviews>> result;

            try
            {
                var response = await ConnectNowApi.GetBusinessReviews(businessReviewsRequest);
                result = await response.ToServiceResult<List<BusinessReviews>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<BusinessReviews>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<List<BusinessReviewsSummary>>> GetBusinessReviewsSummary(GetBusinessReviewsRequest businessReviewsRequest)
        {
            ApiResult<List<BusinessReviewsSummary>> result;

            try
            {
                var response = await ConnectNowApi.GetBusinessReviewsSummary(businessReviewsRequest);
                result = await response.ToServiceResult<List<BusinessReviewsSummary>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<BusinessReviewsSummary>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<string>> Update_User_Privacy(UpdateUserPrivacyRequestModel updateUserPrivacyRequestModel)
        {
            ApiResult<string> result;

            try
            {
                var response = await ConnectNowApi.Update_User_Privacy(updateUserPrivacyRequestModel);
                result = await response.ToServiceResult<string>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<string>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<List<EventItem>>> GetEventsActiveWithFavorite(GetEventsRequest businessReviewsRequest)
        {
            ApiResult<List<EventItem>> result;

            try
            {
                var response = await ConnectNowApi.GetEventsActiveWithFavorite(businessReviewsRequest);
                result = await response.ToServiceResult<List<EventItem>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<EventItem>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<StatusItem>> SubmitReview(ReviewsSubmitRequest reviewsSubmitRequest)
        {
            ApiResult<StatusItem> result;

            try
            {
                var response = await ConnectNowApi.SubmitReview(reviewsSubmitRequest);
                result = await response.ToServiceResult<StatusItem>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<StatusItem>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }

        public async Task<ApiResult<List<UserImagesItem>>> GetUserImages(GetUserImageRequest getUserImageRequest)
        {
            ApiResult<List<UserImagesItem>> result;

            try
            {
                var response = await ConnectNowApi.GetUserImages(getUserImageRequest);
                result = await response.ToServiceResult<List<UserImagesItem>>();
            }
            catch (Exception ex)
            {
                //Logger.Log($"{this.string().ToString()} > Authenticate()", "Authentication failed.", ex);
                result = new ApiResult<List<UserImagesItem>>(false, $"Authentication failed, {ex.Message}.", null);
            }

            return result;
        }
        public async Task<ApiResult<List<EventItem>>> GetEvents(EventRequest eventRequest)
        {
            ApiResult<List<EventItem>> result;

            try
            {
                var response = await ConnectNowApi.GetEvents(eventRequest);
                result = await response.ToServiceResult<List<EventItem>>();
            }
            catch (Exception ex)
            {
                result = new ApiResult<List<EventItem>>(false, $"GetEvents failed, {ex.Message}.", null);
            }
            return result;
        }

    }
}


internal class AuthenticatedHttpClientHandler : HttpClientHandler
    {
        public AuthenticatedHttpClientHandler() { }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var totalElapsedTime = Stopwatch.StartNew();

            Debug.WriteLine(string.Format("Request: {0}", request));
            if (request.Content != null)
            {
                var content = await request.Content.ReadAsStringAsync().ConfigureAwait(false);
                Debug.WriteLine(string.Format("Request Content: {0}", content));
            }

            var responseElapsedTime = Stopwatch.StartNew();
            var response = await base.SendAsync(request, cancellationToken);

            Debug.WriteLine(string.Format("Response: {0}", response));
            if (response.Content != null)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                Debug.WriteLine(string.Format("Response Content: {0}", content));
            }

            responseElapsedTime.Stop();
            Debug.WriteLine(string.Format("Response elapsed time: {0} ms", responseElapsedTime.ElapsedMilliseconds));

            totalElapsedTime.Stop();
            Debug.WriteLine(string.Format("Total elapsed time: {0} ms", totalElapsedTime.ElapsedMilliseconds));

            return response;
        }
    }


