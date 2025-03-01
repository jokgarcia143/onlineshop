using OnlineShop.App.MVVM.ViewModels;
using OnlineShop.App.MVVM.Views.User;
using OnlineShop.App.Services.Implementations;
using OnlineShop.App.Services.Interfaces;

namespace OnlineShop.App.MVVM.Views.Authentication;

public partial class LoginPage : ContentPage
{
    IAuthenticationService _authenticationService { get; set; }
	public LoginPage()
	{
		InitializeComponent();
        _authenticationService = new AuthenticationService();
        BindingContext = new LoginPageViewModel();

    }

    async void btnLogin_Clicked(object sender, EventArgs e)
    {
       var response = await _authenticationService.Authenticate("", "");
    }

    async void btnRegister_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegistrationPage());
    }
}