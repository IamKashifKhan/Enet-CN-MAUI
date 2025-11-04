using EnetCNMAUI.Views.CustomControls;
using Java.Lang;
using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Provider.ContactsContract.CommonDataKinds;
using Webkit = Android.Webkit;

namespace EnetCNMAUI.Platforms
{
    public partial class CustomWebViewHandler : WebViewHandler
    {
        protected override void ConnectHandler(global::Android.Webkit.WebView platformView)
        {
            Clear();
            base.ConnectHandler(platformView);
        }
        protected override global::Android.Webkit.WebView CreatePlatformView()
        {
            var webview = base.CreatePlatformView();
            webview.Settings.BuiltInZoomControls = true;
            webview.Settings.DisplayZoomControls = true;
            webview.Settings.LoadWithOverviewMode = true;
            webview.Settings.UseWideViewPort = true;

            //For sign in by google useragent is required
            webview.Settings.UserAgentString = JavaSystem.GetProperty("http.agent");
            return webview;
        }
        public void Clear()
        {
            var cookieManager = Webkit.CookieManager.Instance;
            cookieManager.RemoveAllCookie();
        }
        public override void SetVirtualView(IView view)
        {
            ((CustomWebView)view).ClearCache += (sender, arg) =>
            {
                Clear();
            };
            base.SetVirtualView(view);
        }
    }
}
