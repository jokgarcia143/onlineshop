using OnlineShop.App.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnlineShop.App.MVVM.ViewModels
{
    public class VerifyViewModel : BaseViewModel
    {
        //Define Properties
        private string _otp;
        public string OTP
        {
            get => _otp;
            set => SetProperty(ref _otp, value);
        }
        //Define Commands
        public ICommand VerifyCommand { get; }

        //Constructor
        public VerifyViewModel()
        {
            VerifyCommand = new Command(Verify);
        }
        //Define Methods
        private async void Verify()
        {
            //Verify OTP
            if(OTP == "1234" && OTP != null)
            {
                //Navigate to Home Page
                //App.Current.MainPage = new AppShell();
                await ToastHelper.ShowToast("OTP Verified Successfully");
            }
            else
            {
                //Show Error Message
            }
        }
    }
}
