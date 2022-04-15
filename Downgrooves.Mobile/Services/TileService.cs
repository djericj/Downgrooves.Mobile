using Downgrooves.Mobile.Controls;
using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.Services.Interfaces;
using Prism.Navigation;
using System.Collections.Generic;

namespace Downgrooves.Mobile.Services
{
    public class TileService : ITileService
    {
        public IEnumerable<Tile> GetTiles()
        {
            return new List<Tile>()
            {
                new Tile() { NavigateTo = "Releases", SvgIcon = Icon.RecordVinyl, Title = "Releases"},
                new Tile() { NavigateTo = "Modular", SvgIcon = Icon.Spinner, Title = "Modular Live"},
                new Tile() { NavigateTo = "Mixes", SvgIcon = Icon.Headphones, Title = "DJ Sets"},
                new Tile() { NavigateTo = "OtherMusic", SvgIcon = Icon.Music, Title = "Other Music"}
            };
        }
    }
}