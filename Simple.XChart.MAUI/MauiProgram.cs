using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Simple.XChart.RoL.Common.Data;
using Simple.XChart.RoL.Common.Models;
using Simple.XChart.RoL.Common.Services;
using Simple.XChart.SharedComponents.Helpers;

namespace Simple.XChart.MAUI
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
                    fonts.AddFont("RobotoMono-Regular.ttf", "RobotoMono");
                    fonts.AddFont("RobotoSlab-Regular.ttf", "RobotoSlab");
                });

            var a = Assembly.GetExecutingAssembly();
            using var stream = Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream("Simple.XChart.MAUI.appsettings.json");
            var config = new ConfigurationBuilder()
                        .AddJsonStream(stream)
                        .Build();

            builder.Services.AddSingleton<StateHelper>();

            builder.Configuration.AddConfiguration(config);

            builder.Services.AddMauiBlazorWebView();

            var connectionSettings = builder.Configuration.GetSection("ConnectionSettings").Get<ConnectionSettings>();
            builder.Services.AddSingleton(connectionSettings);

            var apiSettings = builder.Configuration.GetSection("ApiSettings").Get<ApiSettings>();
            builder.Services.AddSingleton(apiSettings);

            builder.Services.AddScoped(p => new PexelsService(builder.Configuration.GetValue<string>("ApiKeys:pexels")));

            var client = new HttpClient();
            client.BaseAddress = new Uri(apiSettings.ApiUrls.Verse);
            builder.Services.AddScoped(x => new VerseService(client));

            builder.Services.AddScoped(p =>
                new PexelsService(apiSettings.ApiKeys.Pexels)
                );

            var connectionString = Path.Combine(FileSystem.AppDataDirectory, connectionSettings.SqliteConnection);

            var verseService = new VerseService(new HttpClient { BaseAddress = new Uri(apiSettings.ApiUrls.Verse) });
            var pexelsService = new PexelsService(apiSettings.ApiKeys.Pexels);
            var database = new RoLRepositoryHelper(connectionString, pexelsService, verseService);
            database.DatabaseInitialize();
            builder.Services.AddTransient<IRoLRepositoryHelper>(x => database);

            builder.Services.AddMemoryCache();

            builder.Services.AddScoped<SharedComponents.Helpers.JSHelper>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
