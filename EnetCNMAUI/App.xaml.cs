using EnetCNMAUI.Helpers;
using EnetCNMAUI.Services.Session;
using EnetCNMAUI.Services.Theme;
using Plugin.Firebase.CloudMessaging;

namespace EnetCNMAUI
{
    public partial class App : Application
    {
        public static readonly SessionManager _sessionManager = new SessionManager();
        public static SessionManager SessionManager => _sessionManager;
        public static List<object> DarkThemeRecipients = [];


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

        protected override void OnStart()
        {
            base.OnStart();

            // Set status bar and navigation bar colors on app start
            var themeManager = ServiceHelper.GetService<IThemeManager>();
            themeManager?.UpdateAppTheme(AppTheme.Unspecified);
        }
    }
}
