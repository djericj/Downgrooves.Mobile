
using Downgrooves.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Downgrooves.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Modular : ContentPage
    {
        public Modular()
        {
            InitializeComponent();
            this.BindingContext = App.Current.Services.GetService<ModularViewModel>();
        }
    }
}