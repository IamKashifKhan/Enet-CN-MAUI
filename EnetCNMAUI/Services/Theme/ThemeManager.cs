using CommunityToolkit.Mvvm.Messaging;
using EnetCNMAUI.Helpers;
using Microsoft.JSInterop;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnetCNMAUI.Services.Theme
{
    internal class ThemeManager : IThemeManager
    {
        private IJSRuntime jSRuntime;
        public void Register(object recipient, IJSRuntime js) 
        {
            jSRuntime = js;

            // Track every recipient and clear the list when logout or change company
            App.DarkThemeRecipients.Add(recipient);

            WeakReferenceMessenger.Default.Register<UpdateAppThemeEvent>(recipient, (r, m) =>
            {
                jSRuntime.InvokeVoidAsync("applyThemeClass");
            });
        }
        public void UnregisterAll()
        {
            // Unregister all recipient razor pages
            foreach (var recipient in App.DarkThemeRecipients)
            {
                WeakReferenceMessenger.Default.Unregister<UpdateAppThemeEvent>(recipient);
            }
            App.DarkThemeRecipients.Clear();
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
                await jSRuntime.InvokeVoidAsync("setAppTheme", appTheme.ToString().ToLower());

          //UpdateNavBar(appTheme);
          //UpdateNavAndStatusBarTheme();
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
            var shell = ((AppShell)Shell.Current).shellViewModel;

            shell.NavBarTheme.HeaderBg = Color.FromArgb(isLight ? "#1D2C4C" : "#232131");
            shell.NavBarTheme.BodyBg = Color.FromArgb(isLight ? "#FFFFFF" : "#1F1D2B");
            shell.NavBarTheme.FooterBg = Color.FromArgb(isLight ? "#F3F9FE" : "#2D303E");
            shell.NavBarTheme.ItemSelectedColor = Color.FromArgb(isLight ? "#F3F9FE" : "#2D303E");
            shell.NavBarTheme.ItemIconColor = Color.FromArgb(isLight ? "#4A5670" : "#FFFFFF");
            shell.NavBarTheme.ItemTextColor = Color.FromArgb(isLight ? "#1E1F27" : "#FFFFFF");
            shell.NavBarTheme.FooterProfileColor = Color.FromArgb(isLight ? "#1D2C4C" : "#4E5059");
            shell.NavBarTheme.FooterUserColor = Color.FromArgb(isLight ? "#1E1F27" : "#FFFFFF");
            shell.NavBarTheme.FooterEmailColor = Color.FromArgb(isLight ? "#778094" : "#CCCCCC");
            shell.NavBarTheme.SectionHeaderColor = Color.FromArgb(isLight ? "#778094" : "#A38AFF");
        }
        public void UpdateWelcomePageTheme()
        {
            var isLight = GetSelectedTheme() == AppTheme.Light;
            var shell = ((AppShell)Shell.Current).shellViewModel;

            shell.WelcomePageTheme.ScreenBg = Color.FromArgb(isLight ? "#F3F9FE" : "#1F1D2B");
            shell.WelcomePageTheme.CarouselTitleColor = Color.FromArgb(isLight ? "#1D2C4C" : "#FFFFFF");
            shell.WelcomePageTheme.CarouselDescColor = Color.FromArgb(isLight ? "#4A5670" : "#CCCCCCCC");
            shell.WelcomePageTheme.BtnBgColor = Color.FromArgb(isLight ? "#1C85E8" : "#47318D");
            shell.WelcomePageTheme.BtnTextColor = Color.FromArgb(isLight ? "#FFFFFF" : "#FFFFFF");
            shell.WelcomePageTheme.IndicatorColor = Color.FromArgb(isLight ? "FF808080" : "#ACACAF");
            shell.WelcomePageTheme.SelectedIndicatorColor = Color.FromArgb(isLight ? "#000000" : "#FFFFFF");
            shell.WelcomePageTheme.LogoUrl = isLight ? "apexbusinesslogo" : "blazeologowhite";
            shell.WelcomePageTheme.CarouselImg1 = isLight ? "onboarding_1.png" : "onboarding_1_dark.png";
            shell.WelcomePageTheme.CarouselImg2 = isLight ? "onboarding_2.png" : "onboarding_2_dark.png";
            shell.WelcomePageTheme.CarouselImg3 = isLight ? "onboarding_3.png" : "onboarding_3_dark.png";
            shell.WelcomePageTheme.PermissionDialogBg = Color.FromArgb(isLight ? "#FFFFFF" : "#2D303E");
            shell.WelcomePageTheme.PermissionDialogIcon = isLight ? "locked" : "lockeddark";

            UpdateNavAndStatusBarTheme();
        }
        private void UpdateNavAndStatusBarTheme()
        {
            var isLight = GetSelectedTheme() == AppTheme.Light;

#if ANDROID
            var navColor = isLight ? Android.Graphics.Color.White : Android.Graphics.Color.Black;
            var statusColor = Android.Graphics.Color.ParseColor(isLight ? "#1D2C4C" : "#1F1D2B");
            var window = Platform.CurrentActivity.Window;
            window?.SetNavigationBarColor(navColor);  // Dark color for navigation bar
            window?.SetStatusBarColor(statusColor); // Dark color for status bar
#endif
        }
    }
}
