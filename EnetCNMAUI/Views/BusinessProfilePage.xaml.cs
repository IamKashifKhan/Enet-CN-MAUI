using EnetCNMAUI.Views.Base;

namespace EnetCNMAUI.Views;


//[QueryProperty(nameof(BusinessKey), nameof(BusinessKey))]

public partial class BusinessProfilePage : BasePage
{
    //private string businessKey;

    //public string BusinessKey
    //{
    //    get => businessKey;
    //    set
    //    {
    //        businessKey = value;
    //        root.Parameters = new Dictionary<string, object>()
    //        {
    //            {"BusinessKeyweb",  BusinessKey}
    //        };
    //        OnPropertyChanged();
    //    }
    //}
    public BusinessProfilePage()
	{
		InitializeComponent();
        SetRoot(root);
    }
}