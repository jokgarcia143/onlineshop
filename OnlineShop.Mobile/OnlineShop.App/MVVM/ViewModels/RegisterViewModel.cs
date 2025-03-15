using OnlineShop.App.Configuration;
using OnlineShop.App.Helpers;
using OnlineShop.App.MVVM.Models.Request;
using OnlineShop.App.MVVM.Views.Authentication;
using OnlineShop.App.MVVM.Views.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnlineShop.App.MVVM.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        //Define Properties
        private string _email;
        private string _password;
        private string _name;
        
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        //Define Commands
        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        
        
        //Define API Call
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = APIConfig.BaseUrl;

        //Constructor
        public RegisterViewModel()
        {
            LoginCommand = new Command(Login);
            RegisterCommand = new Command(async () => await Register());
            //Initialize the HttpClient
            _httpClient = new HttpClient();
        }
        //Define Methods
        private void Login()
        {
            App.Current.MainPage = new LoginPage();            //Navigate to Login Page
        }
        private async Task Register()
        {
            IsLoading = true;
            ErrorMessage = string.Empty;
            
            var registerData = new RegisterRequest { Name = Name,  Email = Email, Password = Password, Role = "Customer" };
            //Register User
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"http://10.0.2.2:5143/api/auth/register", registerData);
                if (response.IsSuccessStatusCode)
                {
                    await ToastHelper.ShowToast("Registration Successfull");
                    //App.Current.MainPage = new ProductPage();    //Navigate to Login Page
                    await Shell.Current.GoToAsync($"//{nameof(ProductPage)}");
                }
                else
                {
                    ErrorMessage = "An error occurred while registering. Please try again.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"An error occurred: {ex.Message}";
            }

            await ToastHelper.ShowToast(ErrorMessage);
            IsLoading = false;
        }
    }
}
