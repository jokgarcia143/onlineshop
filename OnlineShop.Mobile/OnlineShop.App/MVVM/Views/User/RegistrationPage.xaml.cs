using OnlineShop.App.MVVM.ViewModels;
using OnlineShop.App.Services.DTO;
using OnlineShop.App.Services.Implementations;
using OnlineShop.App.Services.Interfaces;

namespace OnlineShop.App.MVVM.Views.User;

public partial class RegistrationPage : ContentPage
{
	private readonly IUserService _userService;
	public RegistrationPage()
	{
        _userService = new UserService();
        InitializeComponent();
        BindingContext = new RegisterViewModel();
    }

}