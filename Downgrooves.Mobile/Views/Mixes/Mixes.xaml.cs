
using Downgrooves.Mobile.ViewModels.Mixes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Downgrooves.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mixes : ContentPage
    {
        public Mixes()
        {
            InitializeComponent();
            this.BindingContext = App.Current.Services.GetService<MixesViewModel>();
        }
    }
}