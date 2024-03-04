using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NASA.Mobile.Helpers;
using NASA.Mobile.Services;
using NASA.Mobile.ViewModels;

namespace NASA.Mobile
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
                })
                .Configuration.AddJsonFile("secrets.json", optional: true, reloadOnChange: true);


#if DEBUG
            //builder.Configuration.AddUserSecrets(optional: true, reloadOnChange: true);
            builder.Logging.AddDebug();
            var userSecretsFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft", "UserSecrets", "<UserSecretsId>", "secrets.json");
            if (File.Exists(userSecretsFilePath))
            {
                builder.Configuration.AddJsonFile(userSecretsFilePath, optional: true, reloadOnChange: true);
            }
#endif
            //ToDo the following methods could be replaced implementing extension methods.
            RegisterPagesViewModel(builder);
            RegisterServices(builder);
            return builder.Build();
        }

        private static void RegisterPagesViewModel(MauiAppBuilder builder)
        {
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainViewModel>();
        }

        private static void RegisterServices(MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IAlertService, AlertService>();
            builder.Services.AddSingleton<IHttpService, HttpService>();
            builder.Services.AddSingleton<IHttpHelper, HttpHelper>();
            builder.Services.AddSingleton<IRestService, RestService>();
        }
    }
}
