using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNow.Authorization
{
    public interface IAuth0AthenticationService
    {
        Task<LoginResult> LoginAsync();
        Task<BrowserResult> LogoutAsync();
    }
}
