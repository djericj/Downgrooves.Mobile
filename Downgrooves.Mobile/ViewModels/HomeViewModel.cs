using Serilog;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Downgrooves.Mobile.Services.Interfaces;
using Downgrooves.Mobile.Models;
using Microsoft.Toolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ITileService _tileService;

        private IEnumerable<Tile> tiles;

        public IEnumerable<Tile> Tiles
        {
            get { return tiles; }
            set { SetProperty(ref tiles, value); }
        }

        public string BackgroundImage => "resource://Downgrooves.Mobile.Resources.images.pavel-pjatakov-rywx3yUFaa0-unsplash.jpg";

        public ICommand TapTileCommand => new RelayCommand<Tile>(async (tile) =>
        {
            await GoToAsync(tile.NavigateTo);
        });

        public HomeViewModel(INavigationService navigationService, ITileService tileService) : base(navigationService)
        {
            _tileService = tileService;
            Task.Run(() => Load());
        }

        public override async Task Load()
        {
            Tiles = await _tileService.GetTiles();
            Log.Information($"Loading {Tiles} tiles.");
        }

    }
}