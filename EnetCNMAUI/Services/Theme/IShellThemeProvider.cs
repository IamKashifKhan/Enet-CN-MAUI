using EnetCNMAUI.ViewModel;

namespace EnetCNMAUI.Services.Theme
{
    public interface IShellThemeProvider
    {
        NavBarThemeViewModel NavBarTheme { get; }
        WelcomePageThemeViewModel WelcomePageTheme { get; }
    }
}
