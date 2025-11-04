using EnetCNMAUI.ApiService.Requests.MVC;
using EnetCNMAUI.Domain.Models.MVC;
using EnetCNMAUI.Helpers.Extensions;
using EnetCNMAUI.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventItem = EnetCNMAUI.Domain.Models.MVC.EventItem;

namespace EnetCNMAUI.ApiService
{
 
public class CNApiService : ICNApiService
{
    private ICNApi AllAboutLocalApi { get; set; }

    private HttpClient HttpClientInstance { get; set; }

    public CNApiService()
    {
        HttpClientInstance = new HttpClient(new CNAuthenticatedHttpClientHandler()) { BaseAddress = new Uri(Configuration.ServiceBaseUrl) };
        try
        {
            AllAboutLocalApi = RestService.For<ICNApi>(HttpClientInstance);
        }
        catch (Exception ex)
        {

        }
    }

    public async Task<ApiResult<AALUser>> Login(LoginRequest loginRequest)
    {
        ApiResult<AALUser> result;

        try
        {
            var response = await AllAboutLocalApi.Login(loginRequest);
            result = await response.ToServiceResult<AALUser>();
        }
        catch (Exception ex)
        {
            //Logger.Log($"{this.GetType().ToString()} > Authenticate()", "Authentication failed.", ex);
            result = new ApiResult<AALUser>(false, $"Authentication failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<List<CategoryItem>>> GetAppMainCategories(CategoryRequest res)
    {
        ApiResult<List<CategoryItem>> result;

        try
        {
            var response = await AllAboutLocalApi.GetAppMainCategories(res);
            result = await response.ToServiceResult<List<CategoryItem>>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<List<CategoryItem>>(false, $"Getting AppMainCategories failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<List<BusinessItem>>> GetBusinessBasedonSubCategory(CategoryBusinessRequest req)
    {
        ApiResult<List<BusinessItem>> result;

        try
        {
            var response = await AllAboutLocalApi.GetBusinessBasedonSubCategory(req);
            result = await response.ToServiceResult<List<BusinessItem>>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<List<BusinessItem>>(false, $"Getting BusinessBasedonSubCategory failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<BusinessDetailItem>> GetAppBusinessDetail(BusinessDetailoffersRequest businessDetailoffersRequest)
    {
        ApiResult<BusinessDetailItem> result;

        try
        {
            var response = await AllAboutLocalApi.GetAppBusinessDetail(businessDetailoffersRequest);
            result = await response.ToServiceResult<BusinessDetailItem>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<BusinessDetailItem>(false, $"Getting AppBusinessDetail failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<List<BusinessOfferItem>>> GetAppBusinessOffers(BusinessDetailoffersRequest businessDetailoffersRequest)
    {
        ApiResult<List<BusinessOfferItem>> result;

        try
        {
            var response = await AllAboutLocalApi.GetAppBusinessOffers(businessDetailoffersRequest);
            result = await response.ToServiceResult<List<BusinessOfferItem>>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<List<BusinessOfferItem>>(false, $"Getting AppBusinessOffers failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<List<OfferViewResponse>>> AddOfferViewCount(AddOfferViewRequest addOfferViewRequest)
    {
        ApiResult<List<OfferViewResponse>> result;

        try
        {
            var response = await AllAboutLocalApi.AddOfferViewCount(addOfferViewRequest);
            result = await response.ToServiceResult<List<OfferViewResponse>>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<List<OfferViewResponse>>(false, $"Add AddOfferViewCount failed, {ex.Message}.", null);

        }

        return result;
    }

    public async Task<ApiResult<string>> RegisterUserByPhone(RegisterByPhoneRequest registerByPhoneRequest)
    {
        ApiResult<string> result;

        try
        {
            var response = await AllAboutLocalApi.RegisterUserByPhone(registerByPhoneRequest);
            result = await response.ToServiceResult<string>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<string>(false, $"RegisterUserByPhone failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<AALUser>> VerifyUserByPhone(VerifyByPhoneRequest verifyByPhoneRequest)
    {
        ApiResult<AALUser> result;

        try
        {
            var response = await AllAboutLocalApi.VerifyUserByPhone(verifyByPhoneRequest);
            result = await response.ToServiceResult<AALUser>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<AALUser>(false, $"VerifyUserByPhone failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<AALUser>> SetUserPassword(SetUserPasswordRequest setUserPasswordRequest)
    {
        ApiResult<AALUser> result;

        try
        {
            var response = await AllAboutLocalApi.SetUserPassword(setUserPasswordRequest);
            result = await response.ToServiceResult<AALUser>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<AALUser>(false, $"SetUserPassword failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<AALUser>> UpdateUserBio(UpdateUserRequest updateUserRequest)
    {
        ApiResult<AALUser> result;

        try
        {
            var response = await AllAboutLocalApi.UpdateUserBio(updateUserRequest);
            result = await response.ToServiceResult<AALUser>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<AALUser>(false, $"UpdateUserBio failed, {ex.Message}.", null);
        }
        return result;
    }

    public async Task<ApiResult<List<EventItem>>> GetEvents(EventRequest eventRequest)
    {
        ApiResult<List<EventItem>> result;

        try
        {
            var response = await AllAboutLocalApi.GetEvents(eventRequest);
            result = await response.ToServiceResult<List<EventItem>>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<List<EventItem>>(false, $"GetEvents failed, {ex.Message}.", null);
        }
        return result;
    }

    public async Task<ApiResult<string>> RedeemOffer(RedeemOfferRequest redeemOfferRequest)
    {
        ApiResult<string> result;

        try
        {
            var response = await AllAboutLocalApi.RedeemOffer(redeemOfferRequest);
            result = await response.ToServiceResult<string>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<string>(false, $"RedeemOffer failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<List<RedemptionsItem>>> GetUserRedemptions(GetUserRedemptionRequest getUserRedemptionRequest)
    {
        ApiResult<List<RedemptionsItem>> result;

        try
        {
            var response = await AllAboutLocalApi.GetUserRedemptions(getUserRedemptionRequest);
            result = await response.ToServiceResult<List<RedemptionsItem>>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<List<RedemptionsItem>>(false, $"GetUserRedemptions failed, {ex.Message}.", null);
        }
        return result;
    }

    public async Task<ApiResult<RedemptionSummaryItem>> GetUserRedemptionSummary(GetUserRedemptionRequest getUserRedemptionRequest)
    {
        ApiResult<RedemptionSummaryItem> result;

        try
        {
            var response = await AllAboutLocalApi.GetUserRedemptionSummary(getUserRedemptionRequest);
            result = await response.ToServiceResult<RedemptionSummaryItem>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<RedemptionSummaryItem>(false, $"GetUserRedemptionSummary failed, {ex.Message}.", null);
        }
        return result;
    }

    public async Task<ApiResult<List<BusinessItem>>> GetAppBusinessesMap(BusinessMapRequest businessMapRequest)
    {
        ApiResult<List<BusinessItem>> result;

        try
        {
            var response = await AllAboutLocalApi.GetAppBusinessesMap(businessMapRequest);
            result = await response.ToServiceResult<List<BusinessItem>>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<List<BusinessItem>>(false, $"GetAppBusinessesMap failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<string>> OffersMarkUnmarkFavorite(OffersMarkUnmarkFavRequest offersMarkUnmarkFavRequest)
    {
        ApiResult<string> result;

        try
        {
            var response = await AllAboutLocalApi.OffersMarkUnmarkFavorite(offersMarkUnmarkFavRequest);
            result = await response.ToServiceResult<string>();
           // if (result.Success) MessagingCenter.Send<string>("UpdateList", StringConstants.UpdateFavorites);
        }
        catch (Exception ex)
        {
            result = new ApiResult<string>(false, $"GetAppBusinessesMap failed, {ex.Message}.", null);
        }
        return result;
    }


    public async Task<ApiResult<string>> EventMarkUnmarkFavorite(EventMarkUnmarkFavRequest eventMarkUnmarkFavRequest)
    {
        ApiResult<string> result;

        try
        {
            var response = await AllAboutLocalApi.EventMarkUnmarkFavorite(eventMarkUnmarkFavRequest);
            result = await response.ToServiceResult<string>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<string>(false, $"EventMarkUnmarkFavorite failed, {ex.Message}.", null);
        }
        return result;
    }

    public async Task<ApiResult<List<BusinessItem>>> GetCityBusiness(CityBusinessRequest cityBusinessRequest)
    {
        ApiResult<List<BusinessItem>> result;

        try
        {
            var response = await AllAboutLocalApi.GetCityBusiness(cityBusinessRequest);
            result = await response.ToServiceResult<List<BusinessItem>>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<List<BusinessItem>>(false, $"GetCityBusiness failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<List<BusinessOfferItem>>> GetFavoriteOffers(OffersFavoriteRequest offersFavoriteRequest)
    {
        ApiResult<List<BusinessOfferItem>> result;

        try
        {
            var response = await AllAboutLocalApi.GetFavoriteOffers(offersFavoriteRequest);
            result = await response.ToServiceResult<List<BusinessOfferItem>>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<List<BusinessOfferItem>>(false, $"GetFavoriteOffers failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<List<SocialListItem>>> GetBusinessSocial(BusinessDetailoffersRequest businessDetailoffersRequest)
    {
        ApiResult<List<SocialListItem>> result;

        try
        {
            var response = await AllAboutLocalApi.GetBusinessSocial(businessDetailoffersRequest);
            result = await response.ToServiceResult<List<SocialListItem>>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<List<SocialListItem>>(false, $"GetBusinessSocial failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<List<BusinessOfferItem>>> GetOffersFeaturedRandom(OffersFeaturedRequest offersFeaturedRequest)
    {

        ApiResult<List<BusinessOfferItem>> result;

        try
        {
            var response = await AllAboutLocalApi.GetOffersFeaturedRandom(offersFeaturedRequest);
            result = await response.ToServiceResult<List<BusinessOfferItem>>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<List<BusinessOfferItem>>(false, $"GetOffersFeaturedRandom failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<SubscriptionDetails>> UserSubscriptionTransactionDirect(SubscriptionTransactionRequest subscriptionTransactionRequest)
    {
        ApiResult<SubscriptionDetails> result;

        try
        {
            var response = await AllAboutLocalApi.UserSubscriptionTransactionDirect(subscriptionTransactionRequest);
            result = await response.ToServiceResult<SubscriptionDetails>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<SubscriptionDetails>(false, $"UserSubscriptionTransactionDirect failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<List<BusinessTimings>>> AppBusinessSchedule(BusinessDetailoffersRequest businessDetailoffersRequest)
    {
        ApiResult<List<BusinessTimings>> result;

        try
        {
            var response = await AllAboutLocalApi.AppBusinessSchedule(businessDetailoffersRequest);
            result = await response.ToServiceResult<List<BusinessTimings>>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<List<BusinessTimings>>(false, $"AppBusinessSchedule failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<List<PlanDetails>>> AppUsersActiveSubscription(UserSubscriptionPlanRequest userSubscriptionPlanRequest)
    {
        ApiResult<List<PlanDetails>> result;

        try
        {
            var response = await AllAboutLocalApi.AppUsersActiveSubscription(userSubscriptionPlanRequest);
            result = await response.ToServiceResult<List<PlanDetails>>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<List<PlanDetails>>(false, $"AppUsersActiveSubscription failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<UserSubscriptionPlaneItem>> GetAppUserSubscriptionPlan(GetPlanRequest userSubscriptionPlanRequest)
    {
        ApiResult<UserSubscriptionPlaneItem> result;

        try
        {
            var response = await AllAboutLocalApi.GetAppUserSubscriptionPlan(userSubscriptionPlanRequest);
            result = await response.ToServiceResult<UserSubscriptionPlaneItem>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<UserSubscriptionPlaneItem>(false, $"GetAppUserSubscriptionPlan failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<List<UserSubscriptionPlaneItem>>> GetAppUserSubscriptionPlans(GetPlanRequest userSubscriptionPlanRequest)
    {
        ApiResult<List<UserSubscriptionPlaneItem>> result;

        try
        {
            var response = await AllAboutLocalApi.GetAppUserSubscriptionPlans(userSubscriptionPlanRequest);
            result = await response.ToServiceResult<List<UserSubscriptionPlaneItem>>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<List<UserSubscriptionPlaneItem>>(false, $"GetAppUserSubscriptionPlans failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<string>> SetPlanRecurring(SetPlanRecurringRequest userSubscriptionPlanRequest)
    {
        ApiResult<string> result;

        try
        {
            var response = await AllAboutLocalApi.SetPlanRecurring(userSubscriptionPlanRequest);
            result = await response.ToServiceResult<string>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<string>(false, $"GetAppUserSubscriptionPlans failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<string>> UserSubscriptionTransactionOffer(UserSubscriptionTransactionOfferRequest userSubscriptionTransactionOfferRequest)
    {
        ApiResult<string> result;

        try
        {
            var response = await AllAboutLocalApi.UserSubscriptionTransactionOffer(userSubscriptionTransactionOfferRequest);
            result = await response.ToServiceResult<string>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<string>(false, $"GetAppUserSubscriptionPlans failed, {ex.Message}.", null);
        }

        return result;
    }
    public async Task<ApiResult<string>> AppDeleteUserbyID(UserDeletionRequest userDeletionRequest)
    {
        ApiResult<string> result;

        try
        {
            var response = await AllAboutLocalApi.AppDeleteUserbyID(userDeletionRequest);
            result = await response.ToServiceResult<string>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<string>(false, $"GetAppUserSubscriptionPlans failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<List<UserNotificationItem>>> GetUserNotifications(UserNotificationRequest userNotificationRequest)
    {
        ApiResult<List<UserNotificationItem>> result;

        try
        {
            var response = await AllAboutLocalApi.GetUserNotifications(userNotificationRequest);
            result = await response.ToServiceResult<List<UserNotificationItem>>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<List<UserNotificationItem>>(false, $"GetAppUserSubscriptionPlans failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<string>> SubscribeNotificationTopic(SubscribeTopicRequest subscribeTopicRequest)
    {
        ApiResult<string> result;

        try
        {
            var response = await AllAboutLocalApi.SubscribeNotificationTopic(subscribeTopicRequest);
            result = await response.ToServiceResult<string>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<string>(false, $"SubscribeNotificationTopic failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<string>> UnSubscribeNotificationTopic(UnsubscribeTopicRequest unsubscribeTopicRequest)
    {
        ApiResult<string> result;

        try
        {
            var response = await AllAboutLocalApi.UnSubscribeNotificationTopic(unsubscribeTopicRequest);
            result = await response.ToServiceResult<string>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<string>(false, $"UnSubscribeNotificationTopic failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<List<NotificationTopicsItem>>> GetUserNotificationTopics(GetNotificationTopicsRequest getNotificationTopicsRequest)
    {
        ApiResult<List<NotificationTopicsItem>> result;

        try
        {
            var response = await AllAboutLocalApi.GetUserNotificationTopics(getNotificationTopicsRequest);
            result = await response.ToServiceResult<List<NotificationTopicsItem>>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<List<NotificationTopicsItem>>(false, $"GetUserNotificationTopics failed, {ex.Message}.", null);
        }

        return result;
    }


    public async Task<ApiResult<string>> DeleteNotification(DeleteNotificationRequest deleteNotificationRequest)
    {
        ApiResult<string> result;

        try
        {
            var response = await AllAboutLocalApi.DeleteNotification(deleteNotificationRequest);
            result = await response.ToServiceResult<string>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<string>(false, $"DeleteNotification failed, {ex.Message}.", null);
        }

        return result;
    }

    public async Task<ApiResult<List<OffersMapItem>>> GetMapOffers(OfferMapRequest offerMapRequest)
    {
        ApiResult<List<OffersMapItem>> result;

        try
        {
            var response = await AllAboutLocalApi.GetMapOffers(offerMapRequest);
            result = await response.ToServiceResult<List<OffersMapItem>>();
        }
        catch (Exception ex)
        {
            result = new ApiResult<List<OffersMapItem>>(false, $"DeleteNotification failed, {ex.Message}.", null);
        }

        return result;
    }

        public async Task<ApiResult<string>> UpdateCodeReferral(ReferralRequest referralRequest)
        {
            ApiResult<string> result;

            try
            {
                var response = await AllAboutLocalApi.UpdateCodeReferral(referralRequest);
                result = await response.ToServiceResult<string>();
            }
            catch (Exception ex)
            {
                result = new ApiResult<string>(false, $"UpdateCodeReferral failed, {ex.Message}.", null);
            }
return result;
}

public async Task<ApiResult<List<ReferralItem>>> GetAllReferralList(GetAllReferralRequest getAllReferralRequest)
{
ApiResult<List<ReferralItem>> result;

try
{
    var response = await AllAboutLocalApi.GetAllReferralList(getAllReferralRequest);
    result = await response.ToServiceResult<List<ReferralItem>>();
}
catch (Exception ex)
{
    result = new ApiResult<List<ReferralItem>>(false, $"GetAllReferralList failed, {ex.Message}.", null);
}

return result;
}
}

}


internal class CNAuthenticatedHttpClientHandler : HttpClientHandler
{
    public CNAuthenticatedHttpClientHandler() { }

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


