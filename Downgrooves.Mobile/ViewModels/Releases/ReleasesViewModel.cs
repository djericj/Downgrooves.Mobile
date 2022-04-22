using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.Services.Interfaces;
using Xamarin.CommunityToolkit.ObjectModel;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.Input;

namespace Downgrooves.Mobile.ViewModels.Releases
{
    public class ReleasesViewModel : ViewModelBase
    {
        private ObservableRangeCollection<Release> _releases;
        private int _pageSize = App.Settings.MixSettings.PageSize;
        private int _pageNumber = 0;
        private readonly IReleaseService _releaseService;
        private readonly IArtistService _artistService;
        private Artist _artist;
        private int _itemThreshold;
        private bool _isBusy;
        private bool _isRefreshing;

        public ReleasesViewModel(INavigationService navigationService, IReleaseService releaseService, IArtistService artistService) : base(navigationService)
        {
            _releaseService = releaseService;
            _artistService = artistService;

            Task.Run(() => Load());
        }

        public async void Load()
        {
            Artist = await _artistService.GetArtist("Downgrooves");
            LoadReleases();
        }

        public Artist Artist
        {
            get => _artist;
            set { SetProperty(ref _artist, value); }
        }

        public ObservableRangeCollection<Release> Releases
        {
            get { return _releases; }
            set { SetProperty(ref _releases, value); }
        }

        public int ItemThreshold
        {
            get { return _itemThreshold; }
            set { SetProperty(ref _itemThreshold, value); }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); Debug.WriteLine($"IsBusy: {IsBusy}"); }
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); Debug.WriteLine($"IsRefreshing: {IsRefreshing}"); }
        }

        public ICommand LoadReleasesCommand => new RelayCommand(LoadMore);

        public ICommand RefreshCommand => new RelayCommand(Refresh);

        public ICommand NavigateToReleaseCommand => new RelayCommand<Release>(NavigateToRelease);

        public void LoadMore()
        {
            _pageNumber++;
            LoadReleases(_pageNumber);
        }

        public void LoadReleases()
        {
            _pageNumber = 1;
            ItemThreshold = App.Settings.MixSettings.ItemThreshold;
            Releases = new ObservableRangeCollection<Release>();
            LoadReleases(_pageNumber);
        }

        public async void LoadReleases(int pageNumber)
        {
            if (IsBusy) return;

            Debug.WriteLine($"Load More Page Number: {pageNumber}");

            IsBusy = true;

            try
            {
                var releasesList = await _releaseService.GetReleases(pageNumber, _pageSize, artistId: _artist.ArtistId);
                releasesList = releasesList.OrderByDescending(x => x.ReleaseDate);

                if (releasesList.Any())
                {
                    Releases.AddRange(new ObservableRangeCollection<Release>(releasesList));
                    Debug.WriteLine($"{releasesList.Count()} {Releases.Count} ");
                }
                else
                {
                    ItemThreshold = -1;
                    return;
                }
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

        public void Refresh()
        {
            try
            {
                IsRefreshing = true;
                Releases.Clear();
                LoadReleases();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        private async void NavigateToRelease(Release release)
        {
            throw new NotImplementedException();
        }
    }
}