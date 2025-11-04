using EnetCNMAUI.ViewModel;
using EnetCNMAUI.Views;
using EnetCNMAUI.Views.PasswordReset;

namespace EnetCNMAUI;

public partial class AppShell : Shell
{

    public ShellViewModel shellViewModel = new ShellViewModel();
    public AppShell()
	{
		InitializeComponent();
        this.BindingContext = shellViewModel;

        //Shell.TabBarBackgroundColorProperty
        Routing.RegisterRoute(nameof(WelComePage),
          typeof(WelComePage));
        Routing.RegisterRoute(nameof(LoginPage),
          typeof(LoginPage));
        Routing.RegisterRoute(nameof(RegistrationPage),
          typeof(RegistrationPage));
        Routing.RegisterRoute(nameof(RegistrationStartPage),
         typeof(RegistrationStartPage));
        Routing.RegisterRoute(nameof(RegistrationByPhonePage),
         typeof(RegistrationByPhonePage));
        Routing.RegisterRoute(nameof(RegistrationByEmailPage),
         typeof(RegistrationByEmailPage));
        Routing.RegisterRoute(nameof(MorePage),
         typeof(MorePage));
        Routing.RegisterRoute(nameof(OffersPage),
         typeof(OffersPage));
        Routing.RegisterRoute(nameof(BusinessesPage),
         typeof(BusinessesPage));
        Routing.RegisterRoute(nameof(FeedPage),
          typeof(FeedPage));
        Routing.RegisterRoute(nameof(ForgotPasswordPage),
         typeof(ForgotPasswordPage));
        Routing.RegisterRoute(nameof(SignUpPlanPage),
         typeof(SignUpPlanPage));
        Routing.RegisterRoute(nameof(EcommercePage),
        typeof(EcommercePage));
        Routing.RegisterRoute(nameof(RegisterSuccessPage),
     typeof(RegisterSuccessPage));
        Routing.RegisterRoute(nameof(BusinessProfilePage),
      typeof(BusinessProfilePage));
        Routing.RegisterRoute(nameof(MySavingsPage),
    typeof(MySavingsPage));
        Routing.RegisterRoute(nameof(EventDetailPage),
    typeof(EventDetailPage));
        Routing.RegisterRoute(nameof(ManageSubscriptionPage),
        typeof(ManageSubscriptionPage));

    }

    private void HideFlyout_Tapped(object sender, EventArgs e)
    {
        Shell.Current.FlyoutIsPresented = false;
    }

    private async void NavigationEventHandler(object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        var grid = (HorizontalStackLayout)sender;

       // shellViewModel.SelectedPage = grid.AutomationId;
        Shell.Current.FlyoutIsPresented = false;
        try
        {
            //var sessionManager = ServiceHelper.GetService<SessionManager>();
            //if (sessionManager.NavigationStack == null)
            //{
            //    sessionManager.NavigationStack = new();
            //}
        //    App.SessionManager.NavigationStack.Add($"{grid.AutomationId}");
        }
        catch (Exception ex)
        {

        }

       // await Shell.Current.GoToAsync($"//{grid.AutomationId}");

    }

    void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
    }
}