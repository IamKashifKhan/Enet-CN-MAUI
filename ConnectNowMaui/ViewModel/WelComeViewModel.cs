using ConnectNow.Views;
using System.Windows.Input;

namespace ConnectNow.ViewModel
{
    public class WelComeViewModel : BaseViewModel
    {

        public ICommand GotoDashboardCommand => new Command(async () => await GotoDashboard());


        public WelComeViewModel()
        {

        }


        async Task GotoDashboard()
        {
            await Navigation.PushAsync(new WelComePage());
        }
    }
}