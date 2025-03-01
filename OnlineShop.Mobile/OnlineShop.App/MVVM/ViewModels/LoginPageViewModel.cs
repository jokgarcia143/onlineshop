using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnlineShop.App.MVVM.ViewModels
{
    public class LoginPageViewModel : BindableObject
    {
        private string _username;
        private string _password;
        private string _errorMesage;

        public string Username 
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public string ErrorMesage
        {
            get => _errorMesage;
            set { _errorMesage = value; OnPropertyChanged(); }
        }
        public ICommand LoginCommand { get; }

        public LoginPageViewModel()
        {
            LoginCommand = new Command(async () => await Login());
        }

        private async Task Login() 
        {
            ErrorMesage = "";
            try
            {
                using var client = new HttpClient();
                var loginData = new { Username, Password };
                //var response = await client.PostAsJsonAsync($"http://10.0.2.2:5143/api/auth/login", );
            }
            catch (Exception ex) 
            {
            }
        }
    }
}
