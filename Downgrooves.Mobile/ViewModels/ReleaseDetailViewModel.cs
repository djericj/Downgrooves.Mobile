using Downgrooves.Mobile.Services.Interfaces;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Downgrooves.Mobile.ViewModels
{
    public class ReleaseDetailViewModel : ViewModelBase
    {
        private readonly IReleaseService _releaseService;
        private ReleaseViewModel _release;

        public ReleaseViewModel Release
        {
            get => _release;
            set
            {
                _release = value;
                RaisePropertyChanged(nameof(Release));
            }
        }

        public ReleaseDetailViewModel(INavigationService navigationService, IReleaseService releaseService) : base(navigationService)
        {
            _releaseService = releaseService;
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (_release != null) return; // release is already loaded.

            Release = parameters["release"] as ReleaseViewModel;
            if (Release != null)
                Release.Tracks =  await _releaseService.Lookup(Release.CollectionId);
        }

        
    }
}
