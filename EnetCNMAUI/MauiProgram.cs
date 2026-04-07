using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Bundled.Shared;
using CommunityToolkit.Maui;
using EnetCNMAUI.LocalCache;
using EnetCNMAUI.Services;
using EnetCNMAUI.Services.Local;
using EnetCNMAUI.Authorization;
using EnetCNMAUI;
using EnetCNMAUI.Views.CustomControls;
using EnetCNMAUI.Validations;
using EnetCNMAUI.ApiService;
using EnetCNMAUI.Services.Theme;
using EnetCNMAUI.Helpers.Mappings;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using EnetCNMAUI.Helpers;
using EnetCNMAUI.Services;
using Microsoft.Extensions.Configuration;

using Akavache;
using Splat.Builder;
using Akavache.Sqlite3;
using Akavache.SystemTextJson;
using Microsoft.AppCenter;
using Firebase.Analytics;






#if IOS
using Plugin.Firebase.Bundled.Platforms.iOS;
using Plugin.Firebase.Bundled.Shared;

#else
using Plugin.Firebase.Bundled.Platforms.Android;
using Plugin.Firebase.Bundled.Shared;

#endif
namespace EnetCNMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("FontAwesome6Pro-Thin-100.otf", "FontAwesome");
                });
            builder.ConfigureMauiHandlers(handlers =>
              {
                  handlers.AddHandler(typeof(CustomWebView), typeof(Platforms.CustomWebViewHandler));
              });


            // Load configuration from embedded appsettings.json
            var assembly = typeof(MauiProgram).Assembly;
            using var stream = assembly.GetManifestResourceStream("EnetCNMAUI.Resources.Raw.appsettings.json");
            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();
            builder.Configuration.AddConfiguration(config);

            builder.Services.AddMauiBlazorWebView();
            builder.RegisterFirebaseServices();
            builder.Services.RegisterServices(config);
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<AutoMapperProfiles>();
                // cfg.AddProfile<AnotherProfile>();
            });

            // (Optional but safe) ensure SQLitePCLRaw batteries are initialized
            SQLitePCL.Batteries_V2.Init();

            // (Optional but safe) initialize SQLitePCLRaw batteries

            // Akavache v11 init — NOTE the generic type argument:
            CacheDatabase.Initialize<SystemJsonSerializer>(b =>
            {
                b.WithSqliteProvider();   // use SQLite-backed caches
                b.WithSqliteDefaults();   // standard DB locations/flags
            }, applicationName: "EnetCNMAUI");


            AppCenter.Start(
                 $"android={Configuration.AppCenterAndroidAppSecret};" +
                     $"ios={Configuration.AppCenteriOSAppSecret};",
                      typeof(Crashes));

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
            builder.Logging.AddConsole();

#endif

            return builder.Build();
        }


        private static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
        {
            builder.ConfigureLifecycleEvents(events =>
            {
#if IOS
            events.AddiOS(iOS => iOS.FinishedLaunching((app, launchOptions) => {
                CrossFirebase.Initialize(CreateCrossFirebaseSettings());
                //CrossFirebaseCrashlytics.Current.SetCrashlyticsCollectionEnabled(true);
                return false;
            }));
#else
                //events.AddAndroid(android => android.OnCreate((activity, _) => {
                //    var settings = CreateCrossFirebaseSettings();
                //    CrossFirebase.Initialize(activity, settings);
                // }));
              //  events.AddAndroid(android => android.OnCreate((activity, _) =>
                 //   CrossFirebase.Initialize(activity, CreateCrossFirebaseSettings())));
                //CrossFirebaseCrashlytics.Current.SetCrashlyticsCollectionEnabled(true);
#endif
            });

            builder.Services.AddSingleton(_ => CrossFirebaseAuth.Current);
            return builder;
        }

        private static CrossFirebaseSettings CreateCrossFirebaseSettings()
        {
            return new CrossFirebaseSettings(isCloudMessagingEnabled: true, isAnalyticsEnabled: true);
        }
        // Services    }

        private static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {

            //auth0
            services.AddSingleton<ILocalCache, AkavacheLocalCache>();
        // services.AddSingleton<IRemoteAnalytics, FirebaseAnalyticsService>();

            services.AddAuthorizationCore();

           // services.AddSingleton<IApiService, ApiService>();
            services.AddSingleton<ICNApiService, CNApiService>();

            services.AddScoped<IAuth0AthenticationService, Auth0AuthenticationService>();

            services.AddSingleton<ILoginService, LoginService>();
            services.AddSingleton<EmailRegistrationRequestValidator>();

            services.AddTransient<IThemeManager, ThemeManager>();
            services.AddTransient<IOfferService, OfferService>();
            services.AddTransient<ILocationService, LocationService>();

            services.AddSingleton<IFirstPaintNotifier, FirstPaintNotifier>();

            services.AddSingleton<IAppVersion, Platforms.AppVersionService>();

            services.AddSingleton<IMapConfig, MapConfig>();

            return services;
        }
    }
}