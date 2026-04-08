using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using Firebase;
using Plugin.Firebase.CloudMessaging;
using Plugin.Firebase.DynamicLinks;
using Microsoft.Maui.Storage;

namespace EnetCNMAUI
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();
            UpdateStatusBarColor();
        }

        private void UpdateStatusBarColor()
        {
            var theme = Preferences.Get("UserTheme", Preferences.Get("DeviceTheme", "light"));
            var isLight = theme == "light";
            var statusColor = isLight ? Android.Graphics.Color.White : Android.Graphics.Color.ParseColor("#A9A9A9");
            var navColor = isLight ? Android.Graphics.Color.White : Android.Graphics.Color.Black;
            if (Window != null)
            {
                Window.SetStatusBarColor(statusColor);
                Window.SetNavigationBarColor(navColor);
                if (isLight)
                {
                    Window.DecorView.SystemUiVisibility |= (Android.Views.StatusBarVisibility)Android.Views.SystemUiFlags.LightStatusBar;
                }
                else
                {
                    Window.DecorView.SystemUiVisibility &= ~(Android.Views.StatusBarVisibility)Android.Views.SystemUiFlags.LightStatusBar;
                }
            }
        }

        //protected override void OnCreate(Bundle savedInstanceState)
        //{
        //    FirebaseApp.InitializeApp(this);
        //    base.OnCreate(savedInstanceState);
        //    HandleIntent(Intent);
        //    CreateNotificationChannelIfNeeded();
        //    RequestPushNotificationsPermission();
        //}

        //private static void HandleIntent(Intent intent)
        //{
        //    FirebaseCloudMessagingImplementation.OnNewIntent(intent);
        //   // FirebaseDynamicLinksImplementation.HandleDynamicLinkAsync(intent).Ignore();
        //}

        //private void RequestPushNotificationsPermission()
        //{
        //    if (Build.VERSION.SdkInt >= BuildVersionCodes.Tiramisu && ContextCompat.CheckSelfPermission(this, Manifest.Permission.PostNotifications) != Permission.Granted)
        //    {
        //        ActivityCompat.RequestPermissions(this, new[] { Manifest.Permission.PostNotifications }, 0); ;
        //    }
        //}

        //private void CreateNotificationChannelIfNeeded()
        //{
        //    if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
        //    {
        //        CreateNotificationChannel();
        //    }
        //}

        //private void CreateNotificationChannel()
        //{
        //    var channelId = $"{PackageName}.general";
        //    var notificationManager = (NotificationManager)GetSystemService(NotificationService);
        //    var channel = new NotificationChannel(channelId, "General", NotificationImportance.Default);
        //    notificationManager.CreateNotificationChannel(channel);
        //    FirebaseCloudMessagingImplementation.ChannelId = channelId;
        //    //FirebaseCloudMessagingImplementation.SmallIconRef = Resource.Drawable.ic_push_small;
        //}

        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        //{
        //    Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}

        //protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        //{
        //    base.OnActivityResult(requestCode, resultCode, data);
        //}

        //protected override void OnNewIntent(Intent intent)
        //{
        //    base.OnNewIntent(intent);
        //    HandleIntent(intent);
        //}
    }
}
