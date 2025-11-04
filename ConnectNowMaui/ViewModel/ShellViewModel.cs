using System;
namespace ConnectNow.ViewModel
{
	public class ShellViewModel : BaseViewModel
	{
        //IApiService apiService;
        string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }
        string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        string notificationCounter = "0";
        public string NotificationCounter
        {
            get { return notificationCounter; }
            set
            {
                notificationCounter = value;
                OnPropertyChanged("NotificationCounter");
            }
        }
        private bool isActive;
        public bool IsActive
        {
            get { return isActive; }
            set
            {
                if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
                {
                    isActive = value;
                    OnPropertyChanged("IsActive");
                   // UpdateUserStatus(value);
                }
                else
                {
                   // App.Current.MainPage.DisplayAlert(StringConstants.ConnectionErrorHeading, StringConstants.ConnectionErrorDescription, StringConstants.ConnectionErrorDismissMessage); ;
                }
            }
        }

        string selectedPage;
        public string SelectedPage
        {
            get { return selectedPage; }
            set
            {
                selectedPage = value;
                OnPropertyChanged("SelectedPage");
            }
        }

        public NavBarThemeViewModel NavBarTheme { get; set; }
        public WelcomePageThemeViewModel WelcomePageTheme { get; set; }
        public ShellViewModel()
        {
            //GetUserDetails();
            //apiService = ServiceHelper.Current.GetService<IApiService>();
            //ServiceHelper.Current.GetService<NotificationService>().OnChange += UpdateNotificationCounter;
        }

        //private async void UpdateUserStatus(bool value)
        //{
        //    var updateRequest = new UpdateStatusRequest
        //    {
        //        Android = DeviceInfo.Platform == DevicePlatform.Android,
        //        Company = user.CompanyKey,
        //        Online = value
        //    };
        //    await apiService.UpdateAgentStatus(user.UserName, updateRequest);
        //    Preferences.Default.Set(StringConstants.UserStatus, value);
        //}
        //public async void GetUserStatus()
        //{
        //    var result = await apiService.GetAgentStatus(user);
        //    if (result != null && result.Data != null)
        //    {
        //        IsActive = result.Data.Value;
        //        Preferences.Default.Set(StringConstants.UserStatus, IsActive);
        //    }
        //}

        //User user;
        //public async void GetUserDetails()
        //{
        //    var localCache = ServiceHelper.GetService<ILocalCache>();
        //    user = await localCache.GetItem<User>(LocalCacheKeys.User);
        //    if (user != null)
        //    {
        //        UserName = user.DisplayName;
        //        Email = user.Email;
        //    }
        //}
        //public void UpdateNotificationCounter()
        //{
        //    var notificationService = ServiceHelper.GetService<NotificationService>();
        //    if (notificationService.NotificationCounter > 99)
        //    {
        //        this.NotificationCounter = "99+";
        //    }
        //    else
        //    {
        //        this.NotificationCounter = notificationService.NotificationCounter.ToString();
        //    }
        //}
    }
}


