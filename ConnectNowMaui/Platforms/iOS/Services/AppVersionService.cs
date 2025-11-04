using ConnectNow.Services.Local;
using Foundation;
using UIKit;

namespace ConnectNow.Platforms
{
    public class AppVersionService : IAppVersion
    {
        public string GetBuild()
        {
            return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleVersion").ToString();
        }

        public string GetIdentifier()
        {
            return UIDevice.CurrentDevice.IdentifierForVendor.ToString();
        }

        public string GetVersion()
        {
            return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString();
        }
    }
}
