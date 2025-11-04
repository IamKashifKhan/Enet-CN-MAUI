


using EnetCNMAUI.Views.Base;

namespace EnetCNMAUI.Views;


//[QueryProperty(nameof(CategoryId), nameof(CategoryId))]

public partial class BusinessesPage : BasePage
{
    //private string categoryId;

    //public string CategoryId
    //{
    //    get => categoryId;
    //    set
    //    {
    //        categoryId = value;
    //        root.Parameters = new Dictionary<string, object>()
    //        {
    //            {"CategoryIdweb",  CategoryId}
    //        };
    //        OnPropertyChanged();
    //    }
    //}
    public BusinessesPage()
	{
		InitializeComponent();
        SetRoot(root);
    }
}
