using Prism.Commands;
using Prism.Navigation;
using Serilog;
using System.Collections.Generic;
using System.Windows.Input;
using Prism.Navigation.TabbedPages;
using Downgrooves.Mobile.Services.Interfaces;

namespace Downgrooves.Mobile.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ITileService _tileService;

        private IEnumerable<TileViewModel> tiles;

        public IEnumerable<TileViewModel> Tiles
        {
            get { return tiles; }
            set { SetProperty(ref tiles, value); }
        }

        public string BackgroundImage => "resource://Downgrooves.Mobile.Resources.images.pavel-pjatakov-rywx3yUFaa0-unsplash.jpg";

        public ICommand TapTileCommand => new DelegateCommand<TileViewModel>(SelectTab);

        public HomeViewModel(INavigationService navigationService, ITileService tileService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _tileService = tileService;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Tiles = _tileService.GetTiles();
            Log.Information($"Loading {Tiles} tiles.");
        }

        private async void SelectTab(TileViewModel tile)
        {
            await _navigationService.SelectTabAsync(tile.NavigateTo, tile.Parameters);
        }
    }
}