using System;
using Android.App;
using Android.Runtime;

namespace Downgrooves.Mobile.Droid
{
    [Application(
        Theme = "@style/MainTheme",
        UsesCleartextTraffic = true
        )]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            Xamarin.Essentials.Platform.Init(this);
        }
    }
}
