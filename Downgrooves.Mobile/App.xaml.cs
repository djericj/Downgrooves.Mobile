using Downgrooves.Mobile.ApiEndpoints;
using Downgrooves.Mobile.ViewModels;
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
using Xamarin.Essentials;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace Downgrooves.Mobile
{
    public partial class App
    {
        public static AppSettings Settings { get; private set; }

        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            // Get environment file/data
            var contents = GetEmbeddedResource("env.json") ?? "{}";
            var config = JsonConvert.DeserializeObject<Tuple<string, string>>(contents);
            var env = config?.Item2;
            // Register json files for configuration settings
            var fileProvider = new ManifestEmbeddedFileProvider(Assembly.GetExecutingAssembly());
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(fileProvider, "appSettings.json", false, false)
                .AddJsonFile(fileProvider, $"appSettings.{env}.json", true, false)
                .Build();

            Settings = configuration.Get<AppSettings>();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
            //await NavigationService.NavigateAsync("NavigationPage/Mixes");

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppSettings, AppSettings>();
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterSingleton<IMixEndpoint, MixEndpoint>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<Mixes, MixesViewModel>();
        }

        private string GetEmbeddedResource(string fileName)
        {
            try
            {
                // Get stream from manifest
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName))
                {
                    if (stream == null) return null;
                    // Retrieve contents from stream
                    using (var reader = new StreamReader(stream))
                        return reader.ReadToEnd().Trim();
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
