using Downgrooves.Mobile.Services;
using Downgrooves.Mobile.Services.Interfaces;
using Downgrooves.Mobile.ViewModels;
using Downgrooves.Mobile.ViewModels.Mixes;
using Downgrooves.Mobile.ViewModels.Releases;
using Downgrooves.Mobile.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using Serilog;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace Downgrooves.Mobile
{
    public partial class App : Application
    {
        public static AppSettings Settings { get; private set; }

        public IServiceProvider Services { get; set; }

        public new static App Current => (App)Application.Current;

        public App()
        {
            try
            {
                Services = ConfigureServices();
                ConfigureRoutes();
                InitializeComponent();

                // Get environment file/data
                var contents = GetEmbeddedResource("env.json") ?? "{}";
                var config = JsonConvert.DeserializeObject<EnvironmentFile>(contents);
                var env = config?.Env;
                // Register json files for configuration settings
                var fileProvider = new ManifestEmbeddedFileProvider(typeof(App).GetTypeInfo().Assembly);
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile(fileProvider, "appSettings.json", false, false)
                    .Build();

                Settings = configuration.Get<AppSettings>();

                MainPage = new AppShell();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex.Message);
                Log.Fatal(ex.StackTrace);
                Console.Write(ex.ToString());
                throw;
            }
        }

        private static void ConfigureRoutes()
        {
            Routing.RegisterRoute("home", typeof(Home));
            Routing.RegisterRoute("releases", typeof(Releases));
            Routing.RegisterRoute("releases/detail", typeof(ReleaseDetail));
            Routing.RegisterRoute("modular", typeof(Modular));
            Routing.RegisterRoute("mixes", typeof(Mixes));
            Routing.RegisterRoute("mixes/detail", typeof(MixDetail));
            Routing.RegisterRoute("othermusic", typeof(OtherMusic));
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            
            services.AddSingleton<IArtistService, ArtistService>();
            services.AddSingleton<IMixService, MixService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IPlayerService, PlayerService>();
            services.AddSingleton<IReleaseService, ReleaseService>();
            services.AddSingleton<ITileService, TileService>();
            services.AddSingleton<IVideoService, VideoService>();

            services.AddTransient<HomeViewModel>();
            services.AddTransient<ReleasesViewModel>();
            services.AddTransient<ReleaseDetailViewModel>();
            services.AddTransient<MixesViewModel>();
            services.AddTransient<MixDetailViewModel>();
            services.AddTransient<ModularViewModel>();
            services.AddTransient<OtherMusicViewModel>();
            services.AddTransient<MediaPlayerViewModel>();

            return services.BuildServiceProvider();

        }

        private Exception GetInnerException(Exception e)
        {
            while (e.InnerException != null) e = e.InnerException;
            return e;
        }

        private string GetEmbeddedResource(string fileName)
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = Assembly.GetExecutingAssembly().GetManifestResourceNames().Single(str => str.EndsWith(fileName));

                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Log.Error(e, "Can't load embedded resource");
                return null;
            }
        }
    }
}