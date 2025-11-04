using ConnectNow.Services.Local;
using Android.Content.PM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using provider = Android.Provider;

namespace ConnectNow.Platforms
{
    public class AppVersionService : IAppVersion
    {
        public string GetVersion()
        {
            var context = global::Android.App.Application.Context;
            PackageManager manager = context.PackageManager;
            PackageInfo info = manager.GetPackageInfo(context.PackageName, 0);
            return info.VersionName;
        }
        public string GetIdentifier()
        {
            return provider.Settings.Secure.GetString(Platform.CurrentActivity.ApplicationContext.ContentResolver, provider.Settings.Secure.AndroidId);
        }
        public string GetBuild()
        {
            var context = global::Android.App.Application.Context;
            PackageManager manager = context.PackageManager;
            PackageInfo info = manager.GetPackageInfo(context.PackageName, 0);
            return info.VersionCode.ToString();
        }
    }

}
