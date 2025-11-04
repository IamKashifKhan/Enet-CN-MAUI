using AppTrackingTransparency;
using Firebase.CloudMessaging;
using Foundation;
using UIKit;
using UserNotifications;

namespace EnetCNMAUI
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate, IUNUserNotificationCenterDelegate, IMessagingDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();


        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            var result = base.FinishedLaunching(application, launchOptions);
            var authOptions = UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound;
            UNUserNotificationCenter.Current.RequestAuthorization(authOptions, (granted, error) =>
            {
                this.Log($"RequestAuthorization: {granted}" + (error != null ? $" with error: {error.LocalizedDescription}" : string.Empty));

                if (granted && error == null)
                {
                    this.InvokeOnMainThread(() =>
                    {
                        //UIApplication.SharedApplication.UnregisterForRemoteNotifications();
                        //UIApplication.SharedApplication.RegisterForRemoteNotifications();
                        this.InitFirebase();
                    });
                }
            });

            // Handle notification if app is launched from a killed state
            if (launchOptions != null && launchOptions.ContainsKey(UIApplication.LaunchOptionsRemoteNotificationKey))
            {
                NSDictionary notificationOptions = launchOptions[UIApplication.LaunchOptionsRemoteNotificationKey] as NSDictionary;

                if (notificationOptions != null)
                {

                    //To open downloaded file on notification tap in killed state, Currently not working due to firebase notification https://github.com/thudugala/Plugin.LocalNotification/issues/451
                    //var actionValue = notificationOptions.ObjectForKey(new NSString("action"));
                    //if (!string.IsNullOrWhiteSpace(actionValue?.Description))
                    //    MessagingCenter.Send(StringConstants.OpenFile, StringConstants.IncomingChat, new string[] { actionValue.Description });

                }
            }

            return result;
        }

        public void InitFirebase()
        {
            this.Log($"{nameof(this.InitFirebase)}");

            try
            {
                // Load the GoogleService-Info.plist file
                var filePath = NSBundle.MainBundle.PathForResource("GoogleService-Info", "plist");
                var dict = NSDictionary.FromFile(filePath);

                // Extract values from the plist
                var apiKey = dict["API_KEY"].ToString();
                var gcmSenderId = dict["GCM_SENDER_ID"].ToString();
                var googleAppId = dict["GOOGLE_APP_ID"].ToString();
                var bundleId = dict["BUNDLE_ID"].ToString();
                var projectId = dict["PROJECT_ID"].ToString();

                var options = new Firebase.Core.Options(googleAppId, gcmSenderId);
                options.ApiKey = apiKey;
                options.ProjectId = projectId;
                options.BundleId = bundleId;

                Firebase.Core.App.Configure(options);
            }
            catch (Exception x)
            {
                this.Log("Firebase-configure Exception: " + x.Message);
            }

            UNUserNotificationCenter.Current.Delegate = this;

            if (Messaging.SharedInstance != null)
            {
                Messaging.SharedInstance.Delegate = this;
                this.Log("Messaging.SharedInstance SET");
            }
            else
            {
                this.Log("Messaging.SharedInstance IS NULL");
            }
        }
        // indicates that a call to RegisterForRemoteNotifications() failed
        // see developer.apple.com/documentation/uikit/uiapplicationdelegate/1622962-application
        [Export("application:didFailToRegisterForRemoteNotificationsWithError:")]
        public void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
        {
            this.Log($"{nameof(FailedToRegisterForRemoteNotifications)}: {error?.LocalizedDescription}");
        }

        // this callback is called at each app startup
        // it can be called two times:
        //   1. with old token
        //   2. with new token
        // this callback is called whenever a new token is generated during app run
        [Export("messaging:didReceiveRegistrationToken:")]
        public void DidReceiveRegistrationToken(Messaging messaging, string fcmToken)
        {
            this.Log($"{nameof(DidReceiveRegistrationToken)} - Firebase token: {fcmToken}");

            //Utils.RefreshCloudMessagingToken(fcmToken);
        }

        // the message just arrived and will be presented to user
        [Export("userNotificationCenter:willPresentNotification:withCompletionHandler:")]
        public void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
        {
            var parameters = notification.Request.Content.UserInfo;
            this.Log($"{nameof(WillPresentNotification)}: " + parameters);

            // tell the system to display the notification in a standard way
            // or use None to say app handled the notification locally

            // ParseNotificationData(parameters);
            //if (NotificationStatus == TextChatStatus.ApexFlowSMSMessageReceived && Shell.Current.CurrentPage is SMSChatPage)
            //{
            //    var chatPageLeadId = Preferences.Default.Get(AppStringConstants.LeadId, 0);
            //    if (chatPageLeadId == NotificationLeadId)
            //        return;
            //}
            completionHandler(UNNotificationPresentationOptions.Alert);
        }

        // user clicked at presented notification
        [Export("userNotificationCenter:didReceiveNotificationResponse:withCompletionHandler:")]
        public void DidReceiveNotificationResponse(UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler)
        {
            var parameters = response.Notification.Request.Content.UserInfo;
            //To open downloaded file on notification tap
            if (response.Notification.Request.Content.Title == "Downloaded")
            {
                // var notificationRequest = LocalNotificationCenter.GetRequest(response.Notification.Request.Content);
                // MessagingCenter.Send(StringConstants.OpenFile, StringConstants.IncomingChat, new string[] { notificationRequest.Description });
            }
            completionHandler();
        }


        void Log(string msg)
        {
            Console.WriteLine(msg);
        }

    }
}
