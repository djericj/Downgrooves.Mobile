using System.Linq;
using Xamarin.Forms;

namespace Downgrooves.Mobile.Views
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.CurrentPage = Children.Where(x => x is Home).FirstOrDefault();
        }
    }
}