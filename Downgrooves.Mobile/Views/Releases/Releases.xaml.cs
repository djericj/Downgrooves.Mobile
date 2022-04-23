using Downgrooves.Mobile.ViewModels.Releases;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Downgrooves.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Releases : ContentPage
    {
        public Releases()
        {
            InitializeComponent();
            this.BindingContext = App.Current.Services.GetService<ReleasesViewModel>();
        }
    }
}