using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.Services.Interfaces;
using Prism;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Downgrooves.Mobile.ViewModels
{
    public class OtherMusicViewModel : ViewModelBase
    {
        private ObservableCollection<Release> _releases;
        private ObservableCollection<Release> _releases2;
        private readonly IReleaseService _releaseService;
        private readonly IArtistService _artistService;
        private bool _isBusy;

        public OtherMusicViewModel(INavigationService navigationService, IReleaseService releaseService, IArtistService artistService) : base(navigationService)
        {
            _releaseService = releaseService;
            _artistService = artistService;

            IsActiveChanged += (sender, e) =>
            {
                if (sender is OtherMusicViewModel)
                {
                    LoadReleases();
                }
            };
        }

        public ObservableCollection<Release> Releases
        {
            get { return _releases; }
            set { SetProperty(ref _releases, value); }
        }

        public ObservableCollection<Release> Releases2
        {
            get { return _releases2; }
            set { SetProperty(ref _releases2, value); }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public ICommand NavigateToReleaseCommand => new DelegateCommand<Release>(NavigateToRelease);

        public async void LoadReleases()
        {
            var ericRylos = await _artistService.GetArtist("Eric Rylos");
            if (ericRylos != null)
                Releases = await LoadReleases(ericRylos);

            var evotone = await _artistService.GetArtist("Evotone");
            if (evotone != null)
                Releases2 = await LoadReleases(evotone);
        }

        public async Task<ObservableCollection<Release>> LoadReleases(Artist artist)
        {
            ObservableCollection<Release> releases = new ObservableCollection<Release>();
            if (!IsBusy)
            {
                IsBusy = true;

                try
                {
                    var releasesList = await _releaseService.GetReleases(1, 50, artistId: artist.ArtistId);
                    releasesList = releasesList.OrderByDescending(x => x.ReleaseDate);

                    if (releasesList.Any())
                        releases = new ObservableCollection<Release>(releasesList);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    IsBusy = false;
                }
            }
            return releases;
        }

        private async void NavigateToRelease(Release release)
        {
            var props = new NavigationParameters()
            {
                {"release",  release}
            };
            await NavigationService.NavigateAsync("ReleaseDetail", props);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }
    }
}