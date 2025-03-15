using OnlineShop.App.MVVM.ViewModels;

namespace OnlineShop.App.MVVM.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
        BindingContext = new HomeViewModel();
    }
}