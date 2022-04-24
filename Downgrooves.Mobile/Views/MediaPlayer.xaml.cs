
using Downgrooves.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Downgrooves.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MediaPlayer : ContentView
    {
        public MediaPlayer()
        {
            InitializeComponent();
            this.BindingContext = App.Current.Services.GetService<MediaPlayerViewModel>();
        }
    }
}