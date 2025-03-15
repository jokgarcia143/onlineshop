using OnlineShop.App.MVVM.ViewModels;

namespace OnlineShop.App.MVVM.Views.Product;

public partial class ProductPage : ContentPage
{
	public ProductPage()
	{
		InitializeComponent();
        BindingContext = new ProductViewModel();
    }
}