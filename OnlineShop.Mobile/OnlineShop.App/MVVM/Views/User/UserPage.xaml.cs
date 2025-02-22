using OnlineShop.App.MVVM.ViewModels;
using OnlineShop.App.Services.DTO;
using OnlineShop.App.Services.Interfaces;

namespace OnlineShop.App.MVVM.Views.User;

public partial class UserPage : ContentPage
{
    private readonly IUserService _userService;
    public UserPage(IUserService userService)
    {
        InitializeComponent();
        _userService = userService;
    }

   
    private void Button_Clicked_1(object sender, EventArgs e)
    {
        SystemUserDTO userDTO = new SystemUserDTO();

        userDTO.UserName = txtUserName.Text;
        userDTO.UserPassword = txtPassword.Text;
        userDTO.UserEmail = txtEmail.Text;
        userDTO.UserRoles = txtRole.Text;

        _userService.AddUser(userDTO);
    }
}