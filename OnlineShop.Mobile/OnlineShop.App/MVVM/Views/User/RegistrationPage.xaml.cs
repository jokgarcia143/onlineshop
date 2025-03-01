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
	}

    private void btnRegister_Clicked(object sender, EventArgs e)
    {
        var user = new SystemUserDTO();

        //user.FullName = txtName.Text.Trim();
        user.UserName = txtUserName.Text.Trim();
        user.UserPassword = txtPassword.Text.Trim();
        user.Email = txtEmail.Text.Trim();
        user.Role = txtRole.Text.Trim();

        

        _userService.AddUser(user);
    }
}