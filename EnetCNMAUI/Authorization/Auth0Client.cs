using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;
using IdentityModel.Client;
using EnetCNMAUI.LocalCache;
using EnetCNMAUI.Domain.Models;
using EnetCNMAUI.Helpers;
using EnetCNMAUI;

namespace EnetCNMAUI.Authorization;

public class Auth0Client
{
    private readonly OidcClient oidcClient;

    public Auth0Client(Auth0ClientOptions options)
    {
        oidcClient = new OidcClient(new OidcClientOptions
        {
            Authority = $"https://{StringConstants.DomainName}",
            ClientId = StringConstants.ClientId,
            Scope = options.Scope,
            RedirectUri = options.RedirectUri,
            Browser = options.Browser
        });
    }

    public IdentityModel.OidcClient.Browser.IBrowser Browser
    {
        get
        {
            return oidcClient.Options.Browser;
        }
        set
        {
            oidcClient.Options.Browser = value;
        }
    }

    public async Task<LoginResult> LoginAsync()
    {
        ILocalCache localCache =  ServiceHelper.Current.GetService<ILocalCache>();
        //var provider = await localCache.GetItem<SSOProviderDetail>(LocalCacheKeys.SSOProviderDetails);
        Dictionary<string, string> extraParams = new()
        {
            { "audience", StringConstants.Audience }
        };
        LoginRequest request = new()
        {
            FrontChannelExtraParameters = new Parameters(extraParams)
        };
        return await oidcClient.LoginAsync(request);
    }

    public async Task<BrowserResult> LogoutAsync()
    {
        var logoutParameters = new Dictionary<string, string>
    {
      {"client_id", oidcClient.Options.ClientId },
      {"returnTo", oidcClient.Options.RedirectUri }
    };

        var logoutRequest = new LogoutRequest();
        var endSessionUrl = new RequestUrl($"{oidcClient.Options.Authority}/v2/logout")
          .Create(new Parameters(logoutParameters));
        var browserOptions = new BrowserOptions(endSessionUrl, oidcClient.Options.RedirectUri)
        {
            Timeout = TimeSpan.FromSeconds(logoutRequest.BrowserTimeout),
            DisplayMode = logoutRequest.BrowserDisplayMode
        };

        var browserResult = await oidcClient.Options.Browser.InvokeAsync(browserOptions);

        return browserResult;
    }
}