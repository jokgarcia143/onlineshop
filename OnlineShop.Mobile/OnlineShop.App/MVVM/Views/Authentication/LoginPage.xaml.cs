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
	}

    async void btnLogin_Clicked(object sender, EventArgs e)
    {
       var response = await _authenticationService.Authenticate("", "");
    }

    private void btnRegister_Clicked(object sender, EventArgs e)
    {

    }
}