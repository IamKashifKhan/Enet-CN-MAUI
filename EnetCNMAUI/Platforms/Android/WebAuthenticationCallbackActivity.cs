// Platforms/Android/WebAuthenticationCallbackActivity.cs

using Android.App;
using Android.Content.PM;
using content = Android.Content;

namespace EnetCNMAUI.Platforms;

[Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop, Exported = true)]
[IntentFilter(new[] { content.Intent.ActionView },
              Categories = new[] {
                content.Intent.CategoryDefault,
                content.Intent.CategoryBrowsable
              },
DataScheme = CALLBACK_SCHEME)]
public class WebAuthenticationCallbackActivity : Microsoft.Maui.Authentication.WebAuthenticatorCallbackActivity
{
    const string CALLBACK_SCHEME = "EnetCNMAUI";
}