using EnetCNMAUI.LocalCache;
using EnetCNMAUI;
using EnetCNMAUI.Helpers;
using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;

namespace EnetCNMAUI.Authorization;

public class Auth0AuthenticationService : IAuth0AthenticationService
{
    private Auth0Client auth0Client;

    public async Task<LoginResult> LoginAsync()
    {
        auth0Client = await GetClient();
        var loginResult = await auth0Client.LoginAsync();
        return loginResult;
    }

    public async Task<BrowserResult> LogoutAsync()
    {
        auth0Client = await GetClient();
        return await auth0Client.LogoutAsync();
    }
    private async Task<Auth0Client> GetClient()
    {
        var localCache = ServiceHelper.GetService<ILocalCache>();

        auth0Client = new Auth0Client(new()
        {
            Domain = StringConstants.DomainName,
            ClientId = StringConstants.ClientId,
            Scope = "openid profile email",
            RedirectUri = "EnetCNMAUI://callback"
        });

        return auth0Client;
    }
}