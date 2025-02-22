using OnlineShop.App.Repositories;

namespace OnlineShop.App
{
    public partial class App : Application
    {
        public static UserRepository _userRepository {  get; private set; }
        public App(UserRepository userRepository)
        {
            InitializeComponent();
            
            _userRepository = userRepository;

            MainPage = new AppShell();
        }
    }
}
