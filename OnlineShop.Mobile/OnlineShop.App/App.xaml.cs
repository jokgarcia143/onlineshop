using OnlineShop.App.MVVM.Views.Authentication;
using OnlineShop.App.Repositories;

namespace OnlineShop.App
{
    public partial class App : Application
    {
        public static UserRepository _userRepository {  get; private set; }
        public App(UserRepository userRepository)
        {
            InitializeComponent();
            Current.UserAppTheme = AppTheme.Light;
            MainPage = new LoginPage();
            //MainPage = new AppShell();
        }
    }
}
