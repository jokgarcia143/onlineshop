using OnlineShop.App.Configuration;
using OnlineShop.App.Helpers;
using OnlineShop.App.MVVM.Models.Response;
using OnlineShop.App.MVVM.Views.Product;
using OnlineShop.App.MVVM.Views.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnlineShop.App.MVVM.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private string _email;
        private string _password;

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

        
        public ICommand LoginCommand { get; }
        public ICommand LoginFaceBookCommand { get; }
        public ICommand LoginGoogleCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand ForgotPasswordCommand { get; }

        //Define API Call
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = APIConfig.BaseUrl;

        public LoginPageViewModel()
        {
            LoginCommand = new Command(async () => await Login());
            RegisterCommand = new Command(SignUp);
            //Initialize the HttpClient
            _httpClient = new HttpClient();
        }

        private async Task Login() 
        {
            IsLoading = true;
            ErrorMessage = string.Empty;
            var loginData = new { Email, Password };

            try
            {
                //using var client = new HttpClient();
                //var response = await client.PostAsJsonAsync($"http://10.0.2.2:5143/api/auth/login", );
                var response = await _httpClient.PostAsJsonAsync($"http://10.0.2.2:5143/api/auth/login", loginData);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    //Response Mapping to JSON
                    var authResponse = JsonSerializer.Deserialize<AuthenticatedResponse>(responseContent);
                    if (authResponse != null) 
                    {
                        await SecureStorage.SetAsync("tokenStorage", authResponse.token);
                        Application.Current.MainPage = new AppShell();
                    }
                }
                else
                {
                    ErrorMessage = "Invalid email or password";
                    await ToastHelper.ShowToast(ErrorMessage);
                }
            }
            catch (Exception ex) 
            {
                ErrorMessage = $"An API related error occurred: {ex.Message}";
                await ToastHelper.ShowToast(ErrorMessage);
            }
            IsLoading = false;
        }

        private async void SignUp()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new RegistrationPage());
            //Navigate to the registration page
        }
    }
}
