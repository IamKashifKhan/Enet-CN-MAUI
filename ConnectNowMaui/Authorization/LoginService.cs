using Microsoft.Extensions.Configuration;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using System.Reactive.Linq;
using ConnectNow.Services;
using ConnectNow.LocalCache;
using ConnectNow.Helpers;

namespace ConnectNow.Authorization
{
    public class LoginService : ObservableObject, ILoginService
    {
        private readonly ILocalCache localCache;
        private readonly IAuth0AthenticationService auth0AuthenticationService;
        private readonly IConfiguration configuration;
        private IDisposable _storeSession;
        bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public LoginService( ILocalCache localCache, IAuth0AthenticationService auth0AthenticationService, IConfiguration configuration)
        {
            this.localCache = localCache;
            this.auth0AuthenticationService = auth0AthenticationService;
            this.configuration = configuration;
        }

        public async Task Login()
        {
            //if (IsBusy)
            //    return;

            //// Shows the pop up for Allow user tracking to iOS users, this piece is critical for our iOS submissions.
            //if (Device.RuntimePlatform == Device.iOS)
            //{
            //    checkTrackingStatusService.CheckTrackingStatus();
            //}
            try
            {
                if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Alert", "There seems to be some problem with the internet connection.", "OK");
                    return;
                }

                //Navigate to company key page for Non-Native SSO implementation
                //if (!Configuration.IsNativeSSO)
                //{
                //    await NavigationService.NavigateAsync(nameof(WLCompanyKey));
                //    return;
                //}

                //first get sso provider details
                IsBusy = true;


                //check if its a first time login, if so then logout
                //var isFirstLogin = Preferences.Default.Get(StringConstants.IsFirstAppLogin, true);
                //if (isFirstLogin)
                //{
                //    await auth0AuthenticationService.LogoutAsync();
                //}
                await auth0AuthenticationService.LogoutAsync();


                var result = await auth0AuthenticationService.LoginAsync();

                //get user identity from access token
                if (!result.IsError && result.User != null && result.User.Claims != null)
                {
                    var claim = result.User.Claims.Where(x => x.Type == "email").FirstOrDefault();
                    if (claim != null)
                    {
                        //string email = claim.Value;
                        //var userIdentity = await apiService.GetUserIdentity(email, ssoProvider.Data.ProviderId, result.AccessToken);

                        //if (userIdentity != null && userIdentity.Data != null)
                        //{
                        //    //update first login flag
                        //    Preferences.Default.Set(StringConstants.IsFirstAppLogin, false);
                        //    //set access token of auth0
                        //    Preferences.Default.Set(StringConstants.AccessToken, result.AccessToken);
                        //    //set jwt to access companies
                        //    Preferences.Default.Set(StringConstants.JwtToken, userIdentity.Data.JWT);

                        //    await localCache.SaveItem<User>(LocalCacheKeys.User, userIdentity.Data);

                        //    var ShellVM = (ShellViewModel)Shell.Current.BindingContext;
                        //    if (ShellVM != null)
                        //    {
                        //        ShellVM.GetUserDetails();
                        //        ShellVM.GetUserStatus();
                        //    }

                        //    _storeSession = graphQLService.GetUserCompanies(userIdentity.Data.SSOEmail).Select(x => x.Data!.UserCompanies)
                        //    .Subscribe(async(result) =>
                        //    {
                        //        Device.BeginInvokeOnMainThread(async() => {

                        //            var companies = mapper.Map<List<Company>>(result);

                        //            if (companies != null && companies.Count > 0)
                        //            {
                        //                analytics.Log(AnalyticsEventType.Login);
                        //                //direct login user into the app
                        //                if (companies.Count == 1)
                        //                {
                        //                    //set company key
                        //                    Preferences.Default.Set(StringConstants.CompanyKey, companies[0].CompanyKey);

                        //                    //await LoginUser(userIdentity.Data.JWT);
                        //                    Preferences.Default.Set(StringConstants.IsUserLoggedIn, true);
                        //                    //register for push notifications
                        //                    IMessagingService messagingService = ServiceHelper.Current.GetService<IMessagingService>();
                        //                    if (messagingService.IsMessagingAvailable())
                        //                    {
                        //                        messagingService.RegisterNewToken();
                        //                    }
                        //                    await Shell.Current.GoToAsync("//HomePage");
                        //                }
                        //                //show company selector screen
                        //                else if (companies.Count > 1)
                        //                {
                        //                    await localCache.SaveItem<List<Company>>(LocalCacheKeys.UserCompanies, companies);
                        //                    await Shell.Current.GoToAsync("//SelectOrganizationPage");
                        //                }
                        //                else
                        //                {
                        //                    await auth0AuthenticationService.LogoutAsync();
                        //                    await Shell.Current.DisplayAlert("No company found", "No company found for this user.", "OK");
                        //                }
                        //            }
                        //            else
                        //            {
                        //                await auth0AuthenticationService.LogoutAsync();
                        //                await Shell.Current.DisplayAlert("No company found", "No company found for this user.", "OK");
                        //            }
                        //            await Task.Delay(1000);
                        //            IsBusy = false;
                        //        });
                        //    });
                        //}
                        //else
                        //{
                        //    await auth0AuthenticationService.LogoutAsync();
                        //    await Shell.Current.DisplayAlert("User not found", "No sso user found for the email '" + email + "'", "OK");
                        //    IsBusy = false;
                        //}
                    }
                }
                //navigate to migration flow
                else if (result.IsError && result.Error == "Missing authorization code.")
                {
                    await Shell.Current.GoToAsync("//SSOAuthenticationPage");
                    IsBusy = false;
                }
                else if (result.IsError && result.Error == "Invalid state.")
                {
                    await auth0AuthenticationService.LogoutAsync();
                    await Shell.Current.DisplayAlert("Invalid Session", "Please try to login again.", "OK");
                    IsBusy = false;
                }

                //await Task.Delay(1000);
                //IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        bool cm_leads, cm_home, cm_org, cm_workflow, cm_leadDetail;
        public async Task Logout()
        {
            IsBusy = true;
            //GetCoachMarksPref();
            Preferences.Default.Clear();
            await auth0AuthenticationService.LogoutAsync();

           // var user = await localCache.GetItem<User>(LocalCacheKeys.User);

            //var updateRequest = new UpdateStatusRequest
            //{
            //    Android = DeviceInfo.Platform == DevicePlatform.Android,
            //    Company = user.CompanyKey,
            //    Online = false,
            //    Logout = true
            //};
            //Donot update device status
            //if (!skipStatusUpdate)
            //{
            //    //Update agent status and mark it as un avialable
            //    await apiService.UpdateAgentStatus(user.UserName, updateRequest);
            //    //Remove chat device token info
            //    await apiService.UpdateChatDeviceTokenInfo(user.UserId, user.CompanyId, true);
            //}
            //await localCache.SetCredentials(null);
            //Preferences.Default.Set(StringConstants.IsUserLoggedIn, false);
            //Preferences.Default.Set(StringConstants.IsFirstAppLogin, false);
            //SetCoachMarksPref();

            IsBusy = false;
        }
        //private void GetCoachMarksPref()
        //{
        //    cm_leads = Preferences.Default.Get(StringConstants.LeadsCoachMarksShown, false);
        //    cm_home = Preferences.Default.Get(StringConstants.HomeCoachMarksShown, false);
        //    cm_org = Preferences.Default.Get(StringConstants.ChangeOrgCoachMarksShown, false);
        //    cm_workflow = Preferences.Default.Get(StringConstants.WorkflowCoachMarksShown, false);
        //    cm_leadDetail = Preferences.Default.Get(StringConstants.LeadDetailCoachMarksShown, false);
        //}
        //private void SetCoachMarksPref()
        //{
        //    Preferences.Default.Set(StringConstants.LeadsCoachMarksShown, cm_leads);
        //    Preferences.Default.Set(StringConstants.HomeCoachMarksShown, cm_home);
        //    Preferences.Default.Set(StringConstants.ChangeOrgCoachMarksShown, cm_org);
        //    Preferences.Default.Set(StringConstants.WorkflowCoachMarksShown, cm_workflow);
        //    Preferences.Default.Set(StringConstants.LeadDetailCoachMarksShown, cm_leadDetail);
        //}
    }
}
