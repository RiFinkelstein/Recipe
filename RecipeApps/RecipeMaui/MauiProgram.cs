﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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

#if DEBUG
            builder.Logging.AddDebug();
            App.ConnStringSetting = config.GetConnectionString("devconn");
#else
            App.ConnStringSetting = config.GetConnectionString("liveconn");

#endif
            var app = builder.Build();

            IConfiguration configval = app.Services.GetService<IConfiguration>();
            var settingsval = configval.GetRequiredSection("Settings").Get<Settings>();

            //App.ConnStringSetting = settingsval.liveconn.ToString();
            return app;
        }
    }
}


