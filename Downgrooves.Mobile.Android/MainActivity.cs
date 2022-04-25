using Android.App;
using Android.Content.PM;
using Android.OS;
using MediaManager;
using Serilog;

namespace Downgrooves.Mobile.Droid
{
    [Activity(Theme = "@style/MainTheme",
              LaunchMode = LaunchMode.SingleTop,
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
            FFImageLoading.Forms.Platform.CachedImageRenderer.InitImageViewHandler();

            CrossMediaManager.Current.Init(this);

            Log.Logger = new LoggerConfiguration()
                    .WriteTo.AndroidLog()
                    .Enrich.WithProperty("App", "MyCustomTag") //Sets the Tag field.
                    .CreateLogger();

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
    
}

