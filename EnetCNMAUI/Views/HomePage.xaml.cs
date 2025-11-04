using EnetCNMAUI.Helpers;
using EnetCNMAUI.Views.Base;
using Plugin.Firebase.CloudMessaging;

namespace EnetCNMAUI.Views;

public partial class HomePage : BasePage
{
    public HomePage()
    {
        InitializeComponent();
        //var firstPaintNotifier = ServiceHelper.GetService<IFirstPaintNotifier>();
        //firstPaintNotifier.FirstPaint += () =>
        //{
        //    OverlayBox.IsVisible = false;
        //};
        SetRoot(root);
    }

    protected override async void OnAppearing()
    {
        // var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();  

        base.OnAppearing();
    }
}
