﻿using Downgrooves.Mobile.Services.Interfaces;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;

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
            var mixesList = await _mixService.GetMixesAsync();
            mixesList = mixesList.OrderBy(x => x.Name);
            Mixes = new ObservableCollection<MixViewModel>(mixesList);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            LoadMixes();
        }
    }
}
