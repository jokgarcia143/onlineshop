using Microsoft.Extensions.Logging;
using OnlineShop.App.MVVM.ViewModels;
using OnlineShop.App.MVVM.Views.Authentication;
using OnlineShop.App.MVVM.Views.User;
using OnlineShop.App.Repositories;
using OnlineShop.App.Services.Implementations;
using OnlineShop.App.Services.Interfaces;

namespace OnlineShop.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //Page
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<UserPage>();

            //ViewModels
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<UserPageViewModel>();

            //Repository
            builder.Services.AddSingleton<UserRepository>();

            //Services
            builder.Services.AddSingleton<IUserService, UserService>();
            builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
            builder.Services.AddSingleton<IUserService, UserService>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
