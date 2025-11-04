using ConnectNow.Helpers;
using ConnectNow.Views.Base;

namespace ConnectNow.Views;

public partial class LoginPage : BasePage
{
	public LoginPage()
	{
		InitializeComponent();

        if (Preferences.Default.Get(StringConstants.IsUserLoggedIn, false))
        {
            Shell.Current.GoToAsync("//HomePage");
            return;
        }

    }
}
