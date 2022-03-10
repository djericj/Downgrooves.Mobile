using Downgrooves.Mobile.Services.Interfaces;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace Downgrooves.Mobile.ViewModels
{
    public class MixesViewModel : ViewModelBase, INavigationAware
    {
        private readonly IMixService _mixService;
        private ObservableCollection<MixViewModel> _mixes;

        public ObservableCollection<MixViewModel> Mixes 
        { 
            get => _mixes;
            set 
            { 
                _mixes = value;
                RaisePropertyChanged(nameof(Mixes));
            }
        }

        public MixesViewModel(INavigationService navigationService, IMixService mixService) : base(navigationService)
        {
            _mixService = mixService;
        }

        public async void LoadMixes()
        {
            Mixes = new ObservableCollection<MixViewModel>(await _mixService.GetMixesAsync());
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            LoadMixes();
        }
    }
}
