using EnetCNMAUI.ViewModel;
using System.Windows.Input;

namespace EnetCNMAUI.ViewModels

{ 
public class LoginViewModel : BaseViewModel
{

    public ICommand GotoDashboardCommand => new Command(async () => await  GotoDashboard());

        public object MyProperty { get; set; }

        public LoginViewModel()
    {

    }

    
    async Task GotoDashboard()
        {
            try
            {
                
               // await Shell.Current.GoToAsync($"//{nameof(WelComePage)}");
              //  Application.Current.MainPage = new AppShell();
            }
            catch (Exception ex)
            {

                
            }
   
    }
} 
}