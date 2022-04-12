using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.Services.Interfaces;
using Prism.Navigation;
using Xamarin.CommunityToolkit.ObjectModel;
using Prism.Commands;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

namespace Downgrooves.Mobile.ViewModels.Releases
{
    public class ReleasesViewModel : ViewModelBase
    {
        private ObservableRangeCollection<ReleaseViewModel> _releases;
        private int _pageSize = App.Settings.MixSettings.PageSize;
        private int _pageNumber = 0;
        private readonly IReleaseService _releaseService;
        private Artist _artist;
        private int _itemThreshold;
        private bool _isBusy;
        private bool _isRefreshing;

        public ReleasesViewModel(INavigationService navigationService, IReleaseService releaseService) : base(navigationService)
        {
            _releaseService = releaseService;
            this.IsActiveChanged += ReleasesViewModel_IsActiveChanged;
        }

        private void ReleasesViewModel_IsActiveChanged(object sender, EventArgs e)
        {
            if (sender is ReleasesViewModel)
            {
                Artist = new Artist() { ArtistId = 1 };
            }
            LoadReleases();
        }

        public Artist Artist
        {
            get => _artist;
            set { SetProperty(ref _artist, value); }
        }

        public ObservableRangeCollection<ReleaseViewModel> Releases
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

        public ICommand LoadReleasesCommand => new DelegateCommand(LoadMore);

        public ICommand RefreshCommand => new DelegateCommand(Refresh);

        public ICommand NavigateToReleaseCommand => new DelegateCommand<ReleaseViewModel>(NavigateToRelease);

        public void LoadMore()
        {
            _pageNumber++;
            LoadReleases(_pageNumber);
        }

        public void LoadReleases()
        {
            _pageNumber = 1;
            ItemThreshold = App.Settings.MixSettings.ItemThreshold;
            Releases = new ObservableRangeCollection<ReleaseViewModel>();
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
                    Releases.AddRange(new ObservableRangeCollection<ReleaseViewModel>(releasesList));
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

        private async void NavigateToRelease(ReleaseViewModel release)
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