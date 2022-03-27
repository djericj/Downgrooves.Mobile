using Downgrooves.Mobile.Services.Interfaces;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Downgrooves.Mobile.ViewModels
{
    public class ReleasesViewModel : ViewModelBase, INavigationAware
    {
        private int _pageSize = App.Settings.MixSettings.PageSize;
        private int _pageNumber = 0;
        private readonly IReleaseService _releaseService;

        public ICommand LoadReleasesCommand => new DelegateCommand(LoadMore);

        public ICommand RefreshCommand => new DelegateCommand(Refresh);

        public ICommand NavigateToReleaseCommand => new DelegateCommand<ReleaseViewModel>(NavigateToRelease);

        private ObservableRangeCollection<ReleaseViewModel> _releases;

        public ObservableRangeCollection<ReleaseViewModel> Releases
        {
            get { return _releases; }
            set { SetProperty(ref _releases, value); }
        }

        private int _itemThreshold;

        public int ItemThreshold
        {
            get { return _itemThreshold; }
            set { SetProperty(ref _itemThreshold, value); }
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); Debug.WriteLine($"IsBusy: {IsBusy}"); }
        }

        private bool _isRefreshing;

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); Debug.WriteLine($"IsRefreshing: {IsRefreshing}"); }
        }

        public ReleasesViewModel(INavigationService navigationService, IReleaseService releaseService) : base(navigationService)
        {
            _releaseService = releaseService;
        }

        public void Refresh()
        {
            try
            {
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
                var releasesList = await _releaseService.GetReleases(pageNumber, _pageSize);
                releasesList = releasesList.OrderByDescending(x => x.ReleaseDate);

                Releases.AddRange(new ObservableRangeCollection<ReleaseViewModel>(releasesList));

                Debug.WriteLine($"{releasesList.Count()} {Releases.Count} ");
                if (releasesList.Count() == 0)
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

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            LoadReleases();
        }

        private async void NavigateToRelease(ReleaseViewModel release)
        {
            var props = new NavigationParameters()
            {
                {"release",  release}
            };
            await NavigationService.NavigateAsync("ReleaseDetail", props);
        }
    }
}