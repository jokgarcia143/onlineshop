using OnlineShop.App.Repositories;

namespace OnlineShop.App
{
    public partial class App : Application
    {
        public static UserRepository _userRepository {  get; private set; }
        public App(UserRepository userRepository)
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
