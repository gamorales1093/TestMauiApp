
using CommunityToolkit.Maui;
using Controls.UserDialogs.Maui;
using Microsoft.Extensions.Logging;
using TestMauiApp.ViewModels;
using TestMauiApp.Views;
using TestMauiApp.WebServices.Implementation;
using TestMauiApp.WebServices.Interfaces;

namespace TestMauiApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseUserDialogs(() =>
                {
                    //setup your default styles for dialogs
                    AlertConfig.DefaultPositiveButtonTextColor = Color.FromArgb("#2A59A4");
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
             .Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<ProspectListPage>();
            builder.Services.AddTransient<ProspectListPageViewModel>();
            builder.Services.AddTransient<ActivityListPage>();
            builder.Services.AddTransient<ActivityListPageViewModel>();
            builder.Services.AddTransient<ActivityEditPage>();
            builder.Services.AddTransient<ActivityEditPageViewModel>();
            builder.Services.AddTransient<ProfilePage>();
            builder.Services.AddTransient<ProfilePageViewModel>();
            builder.Services.AddSingleton<ISettings, Settings>();
            builder.Services.AddSingleton<IProxyAPI, ProxyAPI>();
            Routing.RegisterRoute(nameof(ActivityListPage), typeof(ActivityListPage));
            Routing.RegisterRoute(nameof(ActivityEditPage), typeof(ActivityEditPage));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
