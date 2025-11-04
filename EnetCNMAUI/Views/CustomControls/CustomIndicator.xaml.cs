namespace EnetCNMAUI.Views.CustomControls;

public partial class CustomIndicator : ContentView
{
    public bool IsBackgroundWhite
    {
        get { return (bool)GetValue(IsBackgroundWhiteProperty); }
        set { this.SetValue(IsBackgroundWhiteProperty, value); }
    }

    public static readonly BindableProperty IsBackgroundWhiteProperty = BindableProperty.Create("IsBackgroundWhite", typeof(bool), typeof(CustomIndicator), false, BindingMode.TwoWay, null, propertyChanged: OnBgColorChangedToWhite);
    public CustomIndicator()
	{
		InitializeComponent();
	}
    public static void OnBgColorChangedToWhite(BindableObject bindable, object oldValue, object newValue)
    {
        if ((bool)newValue)
        {
            ((CustomIndicator)bindable).mainStack.BackgroundColor = Colors.White;
            ((CustomIndicator)bindable).mainStack.Opacity = 1;
        }
    }
}