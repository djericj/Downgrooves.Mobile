using Downgrooves.Mobile.ViewModels.Mixes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Downgrooves.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MixDetail : ContentPage
    {
        public MixDetail()
        {
            InitializeComponent();
            this.BindingContext = App.Current.Services.GetService<MixDetailViewModel>();
        }
    }
}