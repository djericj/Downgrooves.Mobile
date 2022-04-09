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
            get { return tiles; }
            set { SetProperty(ref tiles, value); }
        }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand TapTileCommand => new DelegateCommand<TileViewModel>(async tile =>
                   {
                       await _navigationService.NavigateAsync(tile.NavigateTo, tile.Parameters);
                   });

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Tiles = GetTiles();
        }

        private List<TileViewModel> GetTiles()
        {
            return new List<TileViewModel>()
            {
                new TileViewModel()
                {
                    NavigateTo = "Releases",
                    Parameters = new NavigationParameters()
                    {
                        { "isOriginal", true } ,
                        { "ArtistId", 1 },
                        { "Title", "Releases" }
                    },
                    SvgIcon = "record-vinyl.svg",
                    Title = "Releases"
                },
                new TileViewModel()
                {
                    NavigateTo = "Releases",
                    Parameters = new NavigationParameters()
                    {
                        { "isRemix", true },
                        { "ArtistId", 1 },
                        { "Title", "Remixes" }
                    },
                    SvgIcon = "compact-disc.svg",
                    Title = "Remixes"
                },
                new TileViewModel() { NavigateTo = "Modular", SvgIcon = "spinner.svg", Title = "Modular Live"},
                new TileViewModel() { NavigateTo = "Mixes", SvgIcon = "headphones.svg", Title = "DJ Sets"},
                new TileViewModel()
                {
                    NavigateTo = "OtherMusic",
                    Parameters = new NavigationParameters()
                    {
                        { "ArtistId", 2 },
                        { "ArtistId", 3 }
                    },
                    SvgIcon = "music.svg",
                    Title = "Other Music"
                },
                new TileViewModel() { NavigateTo = "Contact", SvgIcon = "envelope.svg", Title = "Contact Us"}
            };
        }
    }
}