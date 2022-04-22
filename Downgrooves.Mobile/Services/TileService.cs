using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.Services
{
    public class TileService : ITileService
    {
        public async Task<IEnumerable<Tile>> GetTiles()
        {
            return await Task.Run(() =>
            {
                return new List<Tile>()
                {
                    new Tile() { NavigateTo = "Releases", Icon = Fonts.FontAwesomeIcons.RecordVinyl, Title = "Releases" },
                    new Tile() { NavigateTo = "Modular", Icon = Fonts.FontAwesomeIcons.Spinner, Title = "Modular Live" },
                    new Tile() { NavigateTo = "Mixes", Icon = Fonts.FontAwesomeIcons.Headphones, Title = "DJ Sets" },
                    new Tile() { NavigateTo = "OtherMusic", Icon = Fonts.FontAwesomeIcons.Music, Title = "Other Music" }
                };
            });
        }
    }
}