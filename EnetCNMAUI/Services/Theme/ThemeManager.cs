using CommunityToolkit.Mvvm.Messaging;
using EnetCNMAUI.Helpers;
using Microsoft.JSInterop;

namespace EnetCNMAUI.Services.Theme
{
    internal class ThemeManager : IThemeManager
    {
        private readonly IShellThemeProvider _shellThemeProvider;
        private readonly List<object> _themeRecipients = [];
        private IJSRuntime jSRuntime;

        public ThemeManager(IShellThemeProvider shellThemeProvider)
        {
            _shellThemeProvider = shellThemeProvider;
        }

        public void Register(object recipient, IJSRuntime js)
        {
            jSRuntime = js;

            _themeRecipients.Add(recipient);

            WeakReferenceMessenger.Default.Register<UpdateAppThemeEvent>(recipient, (r, m) =>
            {
                jSRuntime.InvokeVoidAsync("applyThemeClass");
            });
        }
        public void UnregisterAll()
        {
            foreach (var recipient in _themeRecipients)
            {
                WeakReferenceMessenger.Default.Unregister<UpdateAppThemeEvent>(recipient);
            }
            _themeRecipients.Clear();
        }
        public async void UpdateAppTheme(AppTheme appTheme)
        {
            // Fetch system default theme
            if (appTheme == AppTheme.Unspecified)
            {
                var theme = Preferences.Get(StringConstants.DeviceTheme, null);
                appTheme = theme == "dark" ? AppTheme.Dark : AppTheme.Light;
                // Clear user pref
                Preferences.Remove(StringConstants.UserTheme);
            }
            else
            {
                Preferences.Set(StringConstants.UserTheme, appTheme.ToString().ToLower());
            }

            Application.Current.UserAppTheme = appTheme;

            if (jSRuntime != null)
               // await jSRuntime.InvokeVoidAsync("setAppTheme", appTheme.ToString().ToLower());

            WeakReferenceMessenger.Default.Send<UpdateAppThemeEvent>();
        }
        public AppTheme GetSelectedTheme()
        {
            var theme = Preferences.Get(StringConstants.UserTheme, Preferences.Get(StringConstants.DeviceTheme, null));
            return theme == "dark" ? AppTheme.Dark : AppTheme.Light;
        }

        private void UpdateNavBar(AppTheme appTheme)
        {
            var isLight = appTheme == AppTheme.Light;
            var navBarTheme = _shellThemeProvider.NavBarTheme;

            navBarTheme.HeaderBg = Color.FromArgb(isLight ? "#1D2C4C" : "#232131");
            navBarTheme.BodyBg = Color.FromArgb(isLight ? "#FFFFFF" : "#1F1D2B");
            navBarTheme.FooterBg = Color.FromArgb(isLight ? "#F3F9FE" : "#2D303E");
            navBarTheme.ItemSelectedColor = Color.FromArgb(isLight ? "#F3F9FE" : "#2D303E");
            navBarTheme.ItemIconColor = Color.FromArgb(isLight ? "#4A5670" : "#FFFFFF");
            navBarTheme.ItemTextColor = Color.FromArgb(isLight ? "#1E1F27" : "#FFFFFF");
            navBarTheme.FooterProfileColor = Color.FromArgb(isLight ? "#1D2C4C" : "#4E5059");
            navBarTheme.FooterUserColor = Color.FromArgb(isLight ? "#1E1F27" : "#FFFFFF");
            navBarTheme.FooterEmailColor = Color.FromArgb(isLight ? "#778094" : "#CCCCCC");
            navBarTheme.SectionHeaderColor = Color.FromArgb(isLight ? "#778094" : "#A38AFF");
        }
        public void UpdateWelcomePageTheme()
        {
            var isLight = GetSelectedTheme() == AppTheme.Light;
            var welcomeTheme = _shellThemeProvider.WelcomePageTheme;

            welcomeTheme.ScreenBg = Color.FromArgb(isLight ? "#F3F9FE" : "#1F1D2B");
            welcomeTheme.CarouselTitleColor = Color.FromArgb(isLight ? "#1D2C4C" : "#FFFFFF");
            welcomeTheme.CarouselDescColor = Color.FromArgb(isLight ? "#4A5670" : "#CCCCCCCC");
            welcomeTheme.BtnBgColor = Color.FromArgb(isLight ? "#1C85E8" : "#47318D");
            welcomeTheme.BtnTextColor = Color.FromArgb(isLight ? "#FFFFFF" : "#FFFFFF");
            welcomeTheme.IndicatorColor = Color.FromArgb(isLight ? "FF808080" : "#ACACAF");
            welcomeTheme.SelectedIndicatorColor = Color.FromArgb(isLight ? "#000000" : "#FFFFFF");
            welcomeTheme.LogoUrl = isLight ? "apexbusinesslogo" : "blazeologowhite";
            welcomeTheme.CarouselImg1 = isLight ? "onboarding_1.png" : "onboarding_1_dark.png";
            welcomeTheme.CarouselImg2 = isLight ? "onboarding_2.png" : "onboarding_2_dark.png";
            welcomeTheme.CarouselImg3 = isLight ? "onboarding_3.png" : "onboarding_3_dark.png";
            welcomeTheme.PermissionDialogBg = Color.FromArgb(isLight ? "#FFFFFF" : "#2D303E");
            welcomeTheme.PermissionDialogIcon = isLight ? "locked" : "lockeddark";

            UpdateNavAndStatusBarTheme();
        }
        private void UpdateNavAndStatusBarTheme()
        {
            var isLight = GetSelectedTheme() == AppTheme.Light;

#if ANDROID
            var navColor = isLight ? Android.Graphics.Color.White : Android.Graphics.Color.Black;
            var statusColor = Android.Graphics.Color.ParseColor(isLight ? "#1D2C4C" : "#1F1D2B");
            var window = Platform.CurrentActivity.Window;
            window?.SetNavigationBarColor(navColor);
            window?.SetStatusBarColor(statusColor);
#endif
        }
    }
}
