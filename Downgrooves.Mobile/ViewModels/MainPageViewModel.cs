using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Windows.Input;

namespace Downgrooves.Mobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private IEnumerable<TileViewModel> tiles;
        public IEnumerable<TileViewModel> Tiles 
        { 
            get {  return tiles; }
            set { SetProperty(ref tiles, value); }  
        }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand TapTileCommand => new DelegateCommand<TileViewModel>(async tile =>
        {
            await _navigationService.NavigateAsync(tile.NavigateTo);
        });

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Tiles = App.Settings.TileSettings.Tiles;
        }
    }
}
