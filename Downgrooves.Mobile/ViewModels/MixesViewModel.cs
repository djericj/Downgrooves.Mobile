using Downgrooves.Mobile.Services.Interfaces;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Downgrooves.Mobile.ViewModels
{
    public class MixesViewModel : ViewModelBase, INavigationAware
    {
        private readonly IMixService _mixService;
        private ObservableCollection<MixViewModel> _mixes;

        public ICommand NavigateToTrackListCommand => new DelegateCommand<MixViewModel>(NavigateToTrackList);
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
            var mixesList = await _mixService.GetMixesAsync();
            mixesList = mixesList.OrderBy(x => x.Name);
            Mixes = new ObservableCollection<MixViewModel>(mixesList);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            LoadMixes();
        }

        private async void NavigateToTrackList(MixViewModel mix)
        {
            var props = new NavigationParameters()
            {
                {"mix",  mix}
            };
            await NavigationService.NavigateAsync("MixDetail", props);
        }
    }
}
