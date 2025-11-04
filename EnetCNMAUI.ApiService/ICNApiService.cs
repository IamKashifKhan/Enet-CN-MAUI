using EnetCNMAUI.ApiService.Requests.MVC;
using EnetCNMAUI.Domain.Models.MVC;
using EnetCNMAUI.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnetCNMAUI.ApiService
{
    [Headers("Accept: application/json")]
    public interface ICNApiService
    {
      
            Task<ApiResult<AALUser>> Login(LoginRequest loginRequest);

            Task<ApiResult<List<CategoryItem>>> GetAppMainCategories(CategoryRequest categoryRequest);

            Task<ApiResult<List<BusinessItem>>> GetBusinessBasedonSubCategory(CategoryBusinessRequest categoryBusinessRequest);

            Task<ApiResult<BusinessDetailItem>> GetAppBusinessDetail(BusinessDetailoffersRequest businessDetailoffersRequest);

            Task<ApiResult<List<BusinessOfferItem>>> GetAppBusinessOffers(BusinessDetailoffersRequest businessDetailoffersRequest);

            Task<ApiResult<List<OfferViewResponse>>> AddOfferViewCount(AddOfferViewRequest addOfferViewRequest);

            Task<ApiResult<string>> RegisterUserByPhone(RegisterByPhoneRequest registerByPhoneRequest);

            Task<ApiResult<AALUser>> VerifyUserByPhone(VerifyByPhoneRequest verifyByPhoneRequest);

            Task<ApiResult<AALUser>> SetUserPassword(SetUserPasswordRequest setUserPasswordRequest);

            Task<ApiResult<AALUser>> UpdateUserBio(UpdateUserRequest updateUserRequest);

            Task<ApiResult<List<Domain.Models.MVC.EventItem>>> GetEvents(EventRequest eventRequest);

            Task<ApiResult<string>> RedeemOffer(RedeemOfferRequest redeemOfferRequest);

            Task<ApiResult<List<RedemptionsItem>>> GetUserRedemptions(GetUserRedemptionRequest getUserRedemptionRequest);

            Task<ApiResult<RedemptionSummaryItem>> GetUserRedemptionSummary(GetUserRedemptionRequest getUserRedemptionRequest);

            Task<ApiResult<List<BusinessItem>>> GetAppBusinessesMap(BusinessMapRequest businessMapRequest);

            Task<ApiResult<string>> OffersMarkUnmarkFavorite(OffersMarkUnmarkFavRequest redeemOfferRequest);

            Task<ApiResult<List<BusinessItem>>> GetCityBusiness(CityBusinessRequest cityBusinessRequest);

            Task<ApiResult<List<BusinessOfferItem>>> GetFavoriteOffers(OffersFavoriteRequest offersFavoriteRequest);

            Task<ApiResult<List<SocialListItem>>> GetBusinessSocial(BusinessDetailoffersRequest businessDetailoffersRequest);

            Task<ApiResult<List<BusinessOfferItem>>> GetOffersFeaturedRandom(OffersFeaturedRequest offersFavoriteRequest);

            Task<ApiResult<SubscriptionDetails>> UserSubscriptionTransactionDirect(SubscriptionTransactionRequest subscriptionTransactionRequest);

            Task<ApiResult<string>> EventMarkUnmarkFavorite(EventMarkUnmarkFavRequest redeemOfferRequest);


            Task<ApiResult<List<BusinessTimings>>> AppBusinessSchedule(BusinessDetailoffersRequest businessDetailoffersRequest);

            Task<ApiResult<List<PlanDetails>>> AppUsersActiveSubscription(UserSubscriptionPlanRequest userSubscriptionPlanRequest);

            Task<ApiResult<UserSubscriptionPlaneItem>> GetAppUserSubscriptionPlan(GetPlanRequest businessMapRequest);

            Task<ApiResult<List<UserSubscriptionPlaneItem>>> GetAppUserSubscriptionPlans(GetPlanRequest businessMapRequest);

            Task<ApiResult<string>> SetPlanRecurring(SetPlanRecurringRequest setPlanRecurringRequest);

            Task<ApiResult<string>> UserSubscriptionTransactionOffer(UserSubscriptionTransactionOfferRequest userSubscriptionTransactionOfferRequest);

            Task<ApiResult<string>> AppDeleteUserbyID(UserDeletionRequest userDeletionRequest);

            Task<ApiResult<List<UserNotificationItem>>> GetUserNotifications(UserNotificationRequest userNotificationRequest);

            Task<ApiResult<string>> SubscribeNotificationTopic(SubscribeTopicRequest subscribeTopicRequest);

            Task<ApiResult<string>> UnSubscribeNotificationTopic(UnsubscribeTopicRequest unsubscribeTopicRequest);

            Task<ApiResult<List<NotificationTopicsItem>>> GetUserNotificationTopics(GetNotificationTopicsRequest getNotificationTopicsRequest);

            Task<ApiResult<string>> DeleteNotification(DeleteNotificationRequest deleteNotificationRequest);

            Task<ApiResult<List<OffersMapItem>>> GetMapOffers(OfferMapRequest offerMapRequest);

            Task<ApiResult<string>> UpdateCodeReferral(ReferralRequest referralRequest);

            Task<ApiResult<List<ReferralItem>>> GetAllReferralList(GetAllReferralRequest getAllReferralRequest);

       }
    }


