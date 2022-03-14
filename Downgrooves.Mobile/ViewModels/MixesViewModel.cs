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
    public class MixesViewModel : ViewModelBase, INavigationAware
    {
        private int _pageSize = App.Settings.MixSettings.PageSize;
        private int _pageNumber = 0;
        private readonly IMixService _mixService;

        public ICommand NavigateToTrackListCommand => new DelegateCommand<MixViewModel>(NavigateToTrackList);
        public ICommand LoadMixesCommand => new DelegateCommand(LoadMore);

        public ICommand RefreshCommand => new DelegateCommand(Refresh);

        private ObservableRangeCollection<MixViewModel> _mixes;
        public ObservableRangeCollection<MixViewModel> Mixes 
        {
            get { return _mixes; }
            set { SetProperty(ref _mixes, value); }
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

        public MixesViewModel(INavigationService navigationService, IMixService mixService) : base(navigationService)
        {
            _mixService = mixService;
        }

        public void Refresh()
        {
            try
            {
                LoadMixes();
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
            LoadMixes(_pageNumber);
        }

        public void LoadMixes()
        {
            _pageNumber = 1;
            ItemThreshold = App.Settings.MixSettings.ItemThreshold;
            Mixes = new ObservableRangeCollection<MixViewModel>();
            LoadMixes(_pageNumber);
        }

        public async void LoadMixes(int pageNumber)
        {
            if (IsBusy) return;

            Debug.WriteLine($"Load More Page Number: {pageNumber}");

            IsBusy = true;

            try
            {
                var mixesList = await _mixService.GetMixesAsync(pageNumber, _pageSize);
                mixesList = mixesList.OrderBy(x => x.Name);
                
                Mixes.AddRange(new ObservableRangeCollection<MixViewModel>(mixesList));

                Debug.WriteLine($"{mixesList.Count()} {Mixes.Count} ");
                if (mixesList.Count() == 0)
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
