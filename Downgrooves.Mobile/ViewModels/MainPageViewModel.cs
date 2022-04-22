using Downgrooves.Mobile.Services.Interfaces;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private int _selectedViewModelIndex;

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public int SelectedViewModelIndex
        {
            get => _selectedViewModelIndex;
            set => SetProperty(ref _selectedViewModelIndex, value);
        }

        public override Task Load()
        {
            return null;
        }
    }
}