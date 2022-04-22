using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.Services.Interfaces;
using Microsoft.Toolkit.Mvvm.Input;
using System;
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
        private int _selectedViewModelIndex;
        private bool _isBusy;

        public OtherMusicViewModel(INavigationService navigationService, IReleaseService releaseService, IArtistService artistService) : base(navigationService)
        {
            _releaseService = releaseService;
            _artistService = artistService;
            Task.Run(() => Load());
        }

        public override async Task Load()
        {
            var ericRylos = await _artistService.GetArtist("Eric Rylos");
            if (ericRylos != null)
                Releases = await LoadReleases(ericRylos);

            var evotone = await _artistService.GetArtist("Evotone");
            if (evotone != null)
                Releases2 = await LoadReleases(evotone);
        }

        public int SelectedViewModelIndex 
        { 
            get => _selectedViewModelIndex; 
            set => SetProperty(ref _selectedViewModelIndex, value); 
        }

        public ObservableCollection<Release> Releases
        {
            get => _releases;
            set => SetProperty(ref _releases, value);
        }

        public ObservableCollection<Release> Releases2
        {
            get => _releases2;
            set => SetProperty(ref _releases2, value);
        }

        public bool IsBusy
        {
            get => _isBusy; 
            set => SetProperty(ref _isBusy, value); 
        }

        public ICommand NavigateToReleaseCommand => new RelayCommand<Release>(NavigateToRelease);

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
            throw new NotImplementedException();
        }

    }
}