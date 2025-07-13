using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
//using NearbyInteraction;
using RecipeMaui;
using System.Reflection;

namespace RecipeMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            var a = Assembly.GetExecutingAssembly();
            var stream = a.GetManifestResourceStream($"{typeof(Settings).Namespace}.secret-appsettings.json");
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Configuration.AddConfiguration(config);
            var app = builder.Build();

            IConfiguration configval = app.Services.GetService<IConfiguration>();
            var settingsval = configval.GetRequiredSection("Settings").Get<Settings>();


#if DEBUG
            builder.Logging.AddDebug();
            App.ConnStringSetting = settingsval.devconn.ToString();

#else
            App.ConnStringSetting = settingsval.liveconn.ToString();

#endif

            return app;
        }
    }
}


