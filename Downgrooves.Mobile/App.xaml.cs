using Downgrooves.Mobile.Services;
using Downgrooves.Mobile.Services.Interfaces;
using Downgrooves.Mobile.ViewModels;
using Downgrooves.Mobile.ViewModels.Releases;
using Downgrooves.Mobile.ViewModels.Mixes;
using Downgrooves.Mobile.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using Prism;
using Prism.Ioc;
using Serilog;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace Downgrooves.Mobile
{
    public partial class App
    {
        public static AppSettings Settings { get; private set; }

        public App() : this(null)
        {
        }

        public App(IPlatformInitializer initializer = null) : base(initializer, setFormsDependencyResolver: true)
        {
        }

        protected override async void OnInitialized()
        {
            try
            {
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

                Current.PageAppearing += (_, page) => Log.Information("Navigated to {name}", page.Title ?? "Home");

                var result = await NavigationService.NavigateAsync("MainPage");
                var f = 1;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex.Message);
                Log.Fatal(ex.StackTrace);
                throw;
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMixService, MixService>();
            containerRegistry.RegisterSingleton<IReleaseService, ReleaseService>();
            containerRegistry.RegisterSingleton<ITileService, TileService>();
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<Home, HomeViewModel>();
            containerRegistry.RegisterForNavigation<Mixes, MixesViewModel>();
            containerRegistry.RegisterForNavigation<MixDetail, MixDetailViewModel>();
            containerRegistry.RegisterForNavigation<Modular, ModularViewModel>();
            containerRegistry.RegisterForNavigation<Releases, ReleasesViewModel>();
            containerRegistry.RegisterForNavigation<ReleaseDetail, ReleaseDetailViewModel>();
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