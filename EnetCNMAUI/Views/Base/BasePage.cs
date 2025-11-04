using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace EnetCNMAUI.Views.Base;

public class BasePage : ContentPage, IQueryAttributable
{  
    // We'll stash latest params here (optional, handy for debugging)
    protected readonly Dictionary<string, object> BlazorParams = new();
    protected RootComponent? Root { get; private set; }

    public BasePage()
	{
        On<iOS>().SetUseSafeArea(true);
    }
    protected void SetRoot(RootComponent root) => Root = root;

    public virtual void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        BlazorParams.Clear();

        foreach (var (k, v) in query)
        {
            var raw = v?.ToString() ?? string.Empty;
            // Decode %20, %2C, etc. into normal characters
            var decoded = Uri.UnescapeDataString(raw);

            BlazorParams[k] = decoded;
        }

        if (Root is not null)
            Root.Parameters = new Dictionary<string, object>(BlazorParams);
    }

}