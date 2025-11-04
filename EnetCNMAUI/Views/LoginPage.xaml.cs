using EnetCNMAUI.Helpers;
using EnetCNMAUI.Views.Base;

namespace EnetCNMAUI.Views;

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
