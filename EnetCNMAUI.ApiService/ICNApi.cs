using EnetCNMAUI.ApiService.Requests.MVC;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnetCNMAUI.ApiService
{

    public interface ICNApi
    {

        [Post("/App_DeleteUser_byID")]
        Task<HttpResponseMessage> AppDeleteUserbyID([Body(BodySerializationMethod.UrlEncoded)] UserDeletionRequest userDeletionRequest);


        [Post("/App_User_Subscription_Transaction_Offer")]
        Task<HttpResponseMessage> UserSubscriptionTransactionOffer([Body(BodySerializationMethod.UrlEncoded)] UserSubscriptionTransactionOfferRequest userSubscriptionTransactionOfferRequest);

        [Post("/App_Users_Active_Subscription")]
        Task<HttpResponseMessage> AppUsersActiveSubscription([Body(BodySerializationMethod.UrlEncoded)] UserSubscriptionPlanRequest userSubscriptionPlanRequest);

        [Post("/App_Business_Schedule")]
        Task<HttpResponseMessage> AppBusinessSchedule([Body(BodySerializationMethod.UrlEncoded)] BusinessDetailoffersRequest eventMarkUnmarkFavRequest);

        [Post("/App_Users_Event_MarkUnmark_Favorite")]
        Task<HttpResponseMessage> EventMarkUnmarkFavorite([Body(BodySerializationMethod.UrlEncoded)] EventMarkUnmarkFavRequest eventMarkUnmarkFavRequest);

        [Post("/App_Offers_Featured_Random5")]
        Task<HttpResponseMessage> GetOffersFeaturedRandom([Body(BodySerializationMethod.UrlEncoded)] OffersFeaturedRequest offersFeaturedRequest);

        [Post("/App_User_Subscription_Transaction_Direct")]
        Task<HttpResponseMessage> UserSubscriptionTransactionDirect([Body(BodySerializationMethod.UrlEncoded)] SubscriptionTransactionRequest subscriptionTransactionRequest);

        [Post("/App_Business_Social")]
        Task<HttpResponseMessage> GetBusinessSocial([Body(BodySerializationMethod.UrlEncoded)] BusinessDetailoffersRequest businessDetailoffersRequest);

        [Post("/App_Get_Users_Business_Offers_Favorite")]
        Task<HttpResponseMessage> GetFavoriteOffers([Body(BodySerializationMethod.UrlEncoded)] OffersFavoriteRequest cityBusinessRequest);

        [Post("/App_Business_Search")]
        Task<HttpResponseMessage> GetCityBusiness([Body(BodySerializationMethod.UrlEncoded)] CityBusinessRequest cityBusinessRequest);

        [Post("/App_Users_Business_Offers_MarkUnmark_Favorite")]
        Task<HttpResponseMessage> OffersMarkUnmarkFavorite([Body(BodySerializationMethod.UrlEncoded)] OffersMarkUnmarkFavRequest businessMapRequest);

        [Post("/App_Business")]
        Task<HttpResponseMessage> GetAppBusinessesMap([Body(BodySerializationMethod.UrlEncoded)] BusinessMapRequest businessMapRequest);

        [Post("/App_User_Redemptions_Summary")]
        Task<HttpResponseMessage> GetUserRedemptionSummary([Body(BodySerializationMethod.UrlEncoded)] GetUserRedemptionRequest getUserRedemptionRequest);

        [Post("/App_User_Redemptions")]
        Task<HttpResponseMessage> GetUserRedemptions([Body(BodySerializationMethod.UrlEncoded)] GetUserRedemptionRequest getUserRedemptionRequest);

        [Post("/App_Redeem_Offers")]
        Task<HttpResponseMessage> RedeemOffer([Body(BodySerializationMethod.UrlEncoded)] RedeemOfferRequest redeemOfferRequest);

        [Post("/App_Events")]
        Task<HttpResponseMessage> GetEvents([Body(BodySerializationMethod.UrlEncoded)] EventRequest setUserPasswordRequest);

        [Post("/App_UpdateUserBio")]
        Task<HttpResponseMessage> UpdateUserBio([Body(BodySerializationMethod.UrlEncoded)] UpdateUserRequest setUserPasswordRequest);

        [Post("/App_UserLogin_Phone")]
        Task<HttpResponseMessage> Login([Body(BodySerializationMethod.UrlEncoded)] LoginRequest setUserPasswordRequest);

        [Post("/App_ForceSetPassword")]
        Task<HttpResponseMessage> SetUserPassword([Body(BodySerializationMethod.UrlEncoded)] SetUserPasswordRequest setUserPasswordRequest);

        [Post("/App_VerifyActivateUser_Phone")]
        Task<HttpResponseMessage> VerifyUserByPhone([Body(BodySerializationMethod.UrlEncoded)] VerifyByPhoneRequest verifyByPhoneRequest);

        [Post("/App_RegisterUser_Phone")]
        Task<HttpResponseMessage> RegisterUserByPhone([Body(BodySerializationMethod.UrlEncoded)] RegisterByPhoneRequest registerByPhoneRequest);

        [Post("/App_Add_Business_Offers_View")]
        Task<HttpResponseMessage> AddOfferViewCount([Body(BodySerializationMethod.UrlEncoded)] AddOfferViewRequest addOfferViewRequest);

        [Post("/App_Business_Offers")]
        Task<HttpResponseMessage> GetAppBusinessOffers([Body(BodySerializationMethod.UrlEncoded)] BusinessDetailoffersRequest businessDetailoffersRequest);

        [Post("/App_Business_Detail")]
        Task<HttpResponseMessage> GetAppBusinessDetail([Body(BodySerializationMethod.UrlEncoded)] BusinessDetailoffersRequest businessDetailoffersRequest);

        [Post("/App_Business_Based_on_SubCategory")]
        Task<HttpResponseMessage> GetBusinessBasedonSubCategory([Body(BodySerializationMethod.UrlEncoded)] CategoryBusinessRequest categoryBusinessRequest);

        [Post("/AppSubCategories_Detail")]
        Task<HttpResponseMessage> GetAppMainCategories([Body(BodySerializationMethod.UrlEncoded)] CategoryRequest categoryRequest);

        [Post("/Get_App_User_Subscription_Plan")]
        Task<HttpResponseMessage> GetAppUserSubscriptionPlan([Body(BodySerializationMethod.UrlEncoded)] GetPlanRequest businessMapRequest);


        [Post("/Get_App_User_Subscription_Plans")]
        Task<HttpResponseMessage> GetAppUserSubscriptionPlans([Body(BodySerializationMethod.UrlEncoded)] GetPlanRequest businessMapRequest);


        [Post("/Set_App_User_Subscription_Recurring")]
        Task<HttpResponseMessage> SetPlanRecurring([Body(BodySerializationMethod.UrlEncoded)] SetPlanRecurringRequest businessMapRequest);



        [Post("/GetUserNotifications")]
        Task<HttpResponseMessage> GetUserNotifications([Body(BodySerializationMethod.UrlEncoded)] UserNotificationRequest userNotificationRequest);


        [Post("/App_Subscribe_Notification_Topic")]
        Task<HttpResponseMessage> SubscribeNotificationTopic([Body(BodySerializationMethod.UrlEncoded)] SubscribeTopicRequest subscribeTopicRequest);


        [Post("/App_UnSubscribe_Notification_Topic")]
        Task<HttpResponseMessage> UnSubscribeNotificationTopic([Body(BodySerializationMethod.UrlEncoded)] UnsubscribeTopicRequest unsubscribeTopicRequest);


        [Post("/App_Get_User_Notification_Topics")]
        Task<HttpResponseMessage> GetUserNotificationTopics([Body(BodySerializationMethod.UrlEncoded)] GetNotificationTopicsRequest userNotificationRequest);

        [Post("/App_Delete_User_Notification")]
        Task<HttpResponseMessage> DeleteNotification([Body(BodySerializationMethod.UrlEncoded)] DeleteNotificationRequest userNotificationRequest);

        [Post("/App_BusinessOffer_Geo")]
        Task<HttpResponseMessage> GetMapOffers([Body(BodySerializationMethod.UrlEncoded)] OfferMapRequest offerMapRequest);

        [Post("/UpdateCodeReferral")]
        Task<HttpResponseMessage> UpdateCodeReferral([Body(BodySerializationMethod.UrlEncoded)] ReferralRequest referralRequest);

        [Post("/GetAllReferralList")]
        Task<HttpResponseMessage> GetAllReferralList([Body(BodySerializationMethod.UrlEncoded)] GetAllReferralRequest GetAllReferralRequest);

    }
}