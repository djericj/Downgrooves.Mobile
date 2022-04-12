using Downgrooves.Mobile.Controls;
using Downgrooves.Mobile.Services.Interfaces;
using Downgrooves.Mobile.ViewModels;
using Prism.Navigation;
using System.Collections.Generic;

namespace Downgrooves.Mobile.Services
{
    public class TileService : ITileService
    {
        public IEnumerable<TileViewModel> GetTiles()
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
                }
            };
        }
    }
}