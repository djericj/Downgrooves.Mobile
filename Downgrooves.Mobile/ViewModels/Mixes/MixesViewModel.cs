using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.Services.Interfaces;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Downgrooves.Mobile.ViewModels.Mixes
{
    public class MixesViewModel : ViewModelBase
    {
        private int _pageSize = App.Settings.MixSettings.PageSize;
        private int _pageNumber = 0;
        private readonly IMixService _mixService;

        public ICommand NavigateToTrackListCommand => new RelayCommand<Mix>(NavigateToTrackList);
        public ICommand LoadMixesCommand => new RelayCommand(async () => await LoadMore());

        public ICommand RefreshCommand => new RelayCommand(async () => await Refresh());

        private ObservableRangeCollection<Mix> _mixes;

        public ObservableRangeCollection<Mix> Mixes
        {
            get => _mixes;
            set => SetProperty(ref _mixes, value);
        }

        private int _itemThreshold;

        public int ItemThreshold
        {
            get => _itemThreshold; 
            set => SetProperty(ref _itemThreshold, value);
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

        public MixesViewModel(IPlayerService playerService, IMixService mixService) : base(playerService)
        {
            _mixService = mixService;
            Task.Run(() => Load());
        }

        public async override Task Load()
        {
            await LoadMixes();
        }

        public async Task Refresh()
        {
            try
            {
                Mixes.Clear();
                await LoadMixes();
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

        public async Task LoadMore()
        {
            _pageNumber++;
            await LoadMixes(_pageNumber);
        }

        public async Task LoadMixes()
        {
            _pageNumber = 1;
            ItemThreshold = App.Settings.MixSettings.ItemThreshold;
            Mixes = new ObservableRangeCollection<Mix>();
            await LoadMixes(_pageNumber);
        }

        public async Task LoadMixes(int pageNumber)
        {
            if (IsBusy) return;

            Debug.WriteLine($"Load More Page Number: {pageNumber}");

            IsBusy = true;

            try
            {
                var mixesList = await _mixService.GetMixesAsync(pageNumber, _pageSize);
                mixesList = mixesList.OrderBy(x => x.Title);

                Mixes.AddRange(new ObservableRangeCollection<Mix>(mixesList));

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

        private async void NavigateToTrackList(Mix mix)
        {
            await GoToAsync($"details?mix={mix}");
        }

        
    }
}