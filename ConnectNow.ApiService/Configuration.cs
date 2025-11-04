using System;
namespace ConnectNow
{
    public static class Configuration
    {
        private static string Schema => "https";
        //private static string Host = "127.0.0.1:8080/APIWebService.asmx";
        private static string Host = "allaboutlocal.azurewebsites.net/APIWebService.asmx";
        private static string ServiceAuthorizationKey => "SERVICEkeyTLP";
        private static string WebUri = "http://enettlp.azurewebsites.net/";
        private static string Port => "";
        public static string ServiceBaseUrl => $"{Schema}://{Host}";
        public static string WebSyncHandler => "";
        public static string ApiKey => "190747504702"; //GCM key
        public static string AppCenterAndroidAppSecret => "adc0374e-03b7-44a1-863b-df2361f514b2";
        public static string AppCenteriOSAppSecret => "d3b27df1-528b-40e4-a0b0-00a6a95551e7";
        public static string ResetPasswordPage => "";

        public static readonly string Authorization = "123";
        public static readonly string AppId = "AAL_Mindy";

        public static readonly string PolicyProfileUri = "";
        public static readonly string TermsAndConditionsUri = "";
        public static readonly string AuthorizationKey = "SERVICEkeyTLP";
    }
}
