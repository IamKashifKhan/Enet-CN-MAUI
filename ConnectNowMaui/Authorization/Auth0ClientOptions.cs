namespace ConnectNow.Authorization;

public class Auth0ClientOptions
{
    public Auth0ClientOptions()
    {
        Scope = "openid profile email";
        //RedirectUri = "com.crm.live://apexconnect.auth0.com/android/com.crm.live/callback";
        RedirectUri = "apexconnect://callback";
        Browser = new WebBrowserAuthenticator();
    }

    public string Domain { get; set; }

    public string ClientId { get; set; }

    public string RedirectUri { get; set; }

    public string Scope { get; set; }

    public IdentityModel.OidcClient.Browser.IBrowser Browser { get; set; }
}
