using Downgrooves.Mobile.Services.Interfaces;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Downgrooves.Mobile.ViewModels
{
    public class ReleaseDetailViewModel : ViewModelBase
    {
        private readonly IReleaseService _releaseService;
        private ReleaseViewModel _release;

        public ICommand OpenLinkCommand => new DelegateCommand<string>(OpenLink);

        public ReleaseViewModel Release
        {
            get => _release;
            set
            {
                _release = value;
                RaisePropertyChanged(nameof(Release));
            }
        }

        private string _previewIcon;
        public string PreviewIcon
        {
            get { return _previewIcon; }
            set { SetProperty(ref _previewIcon, value); }
        }

        public ReleaseDetailViewModel(INavigationService navigationService, IReleaseService releaseService) : base(navigationService)
        {
            _releaseService = releaseService;
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            
            PreviewIcon = "resource://Downgrooves.Mobile.Resources.play.svg";

            if (_release != null) return; // release is already loaded.

            Release = parameters["release"] as ReleaseViewModel;
            if (Release != null)
            {
                var tracks = await _releaseService.Lookup(Release.CollectionId);
                Release.Tracks = tracks.Where(x => x.WrapperType == "track").ToList();
                RaisePropertyChanged(nameof(Release));
            }
                
        }

        
    }
}
