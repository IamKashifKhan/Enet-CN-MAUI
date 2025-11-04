using EnetCNMAUI.Domain.Models.MVC;
using EnetCNMAUI.Helpers;
using EnetCNMAUI.Services.Session;
using Plugin.Firebase.CloudMessaging;

namespace EnetCNMAUI
{
    public partial class App : Application
    {
        public static readonly SessionManager _sessionManager = new SessionManager();
        public static SessionManager SessionManager => _sessionManager;
        public static List<object> DarkThemeRecipients = [];
        public static AALUser CurrentUser = new AALUser();
        public static PlanDetails PlanDetails = new PlanDetails();
        public static string DiscountCode = "";
        public static Location MyPosition { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            // Set device current theme
            Preferences.Set(StringConstants.DeviceTheme, Current.PlatformAppTheme.ToString().ToLower());


            CrossFirebaseCloudMessaging.Current.NotificationReceived += (s, p) =>
            {

                var jj = s;
            };

        }
    }
}
