
using Downgrooves.Mobile.ViewModels.Releases;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Downgrooves.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReleaseDetail : ContentPage
    {
        public ReleaseDetail()
        {
            InitializeComponent();
            this.BindingContext = App.Current.Services.GetService<ReleaseDetailViewModel>();
        }
    }
}