using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Downgrooves.Mobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private IEnumerable<TileViewModel> tiles;

        public IEnumerable<TileViewModel> Tiles 
        { 
            get => tiles;
            set
            { 
                tiles = value;
                RaisePropertyChanged(nameof(Tiles));
            }
        }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            _navigationService = navigationService;
            LoadTiles();
        }

        public ICommand TapTileCommand => new DelegateCommand<TileViewModel>(async tile =>
        {
            await _navigationService.NavigateAsync(tile.NavigateTo);
        });

        private void LoadTiles()
        {
            var tiles = new List<TileViewModel>();
            tiles.Add(new TileViewModel() { SvgIcon = "record-vinyl.svg", NavigateTo = "Releases", Title = "Releases" });
            tiles.Add(new TileViewModel() { SvgIcon = "headphones.svg", NavigateTo = "Mixes", Title = "DJ Sets" });
            tiles.Add(new TileViewModel() { SvgIcon = "spinner.svg", NavigateTo = "Modular", Title = "Modular Live" });
            tiles.Add(new TileViewModel() { SvgIcon = "envelope.svg", NavigateTo = "Contact", Title = "Contact Us" });
            Tiles = tiles;
        }
    }
}
