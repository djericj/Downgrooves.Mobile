using Downgrooves.Mobile.Controls;
using Prism.Commands;
using Prism.Navigation;
using Serilog;
using System.Collections.Generic;
using System.Windows.Input;
using Prism.Navigation.TabbedPages;

namespace Downgrooves.Mobile.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private IEnumerable<TileViewModel> tiles;

        public IEnumerable<TileViewModel> Tiles
        {
            get { return tiles; }
            set { SetProperty(ref tiles, value); }
        }

        public DelegateCommand<string> OnNavigateCommand { get; set; }

        public string BackgroundImage => "resource://Downgrooves.Mobile.Resources.images.pavel-pjatakov-rywx3yUFaa0-unsplash.jpg";

        public HomeViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            OnNavigateCommand = new DelegateCommand<string>(NavigateAsync);
        }

        public async void NavigateAsync(string page)
        {
            await _navigationService.NavigateAsync(new System.Uri(page, System.UriKind.Relative));
        }

        public ICommand TapTileCommand => new DelegateCommand<TileViewModel>(async tile =>
             {
                 await _navigationService.SelectTabAsync(tile.NavigateTo, tile.Parameters);
             });

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Tiles = GetTiles();
            Log.Information($"Loading {Tiles} tiles.");
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
                        { "IsOriginal", true } ,
                        { "ArtistId", 1 },
                        { "Title", "Releases" }
                    },
                    SvgIcon = Icon.RecordVinyl,
                    Title = "Releases"
                },
                new TileViewModel()
                {
                    NavigateTo = "Remixes",
                    Parameters = new NavigationParameters()
                    {
                        { "IsRemix", true },
                        { "ArtistId", 1 },
                        { "Title", "Remixes" }
                    },
                    SvgIcon = Icon.CompactDisc,
                    Title = "Remixes"
                },
                new TileViewModel() { NavigateTo = "Modular", SvgIcon = Icon.Spinner, Title = "Modular Live"},
                new TileViewModel() { NavigateTo = "Mixes", SvgIcon = Icon.Headphones, Title = "DJ Sets"},
                new TileViewModel()
                {
                    NavigateTo = "OtherMusic",
                    Parameters = new NavigationParameters()
                    {
                        { "ArtistId", 2 },
                        { "ArtistId", 3 }
                    },
                    SvgIcon = Icon.Music,
                    Title = "Other Music"
                },
                new TileViewModel() { NavigateTo = "Contact", SvgIcon = Icon.Envelope, Title = "Contact Us"}
            };
        }
    }
}