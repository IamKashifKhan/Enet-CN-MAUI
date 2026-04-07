using EnetCNMAUI.Helpers;
using EnetCNMAUI.ViewModel;
using Plugin.Firebase.CloudMessaging;

namespace EnetCNMAUI
{
    public partial class App : Application
    {
        public App(ShellViewModel shellViewModel)
        {
            InitializeComponent();

            MainPage = new AppShell(shellViewModel);

            // Set device current theme
            Preferences.Set(StringConstants.DeviceTheme, Current.PlatformAppTheme.ToString().ToLower());

            CrossFirebaseCloudMessaging.Current.NotificationReceived += (s, p) =>
            {
            };
        }
    }
}
