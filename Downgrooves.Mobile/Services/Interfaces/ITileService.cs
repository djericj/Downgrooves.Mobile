using Downgrooves.Mobile.Models;
using System.Collections.Generic;

namespace Downgrooves.Mobile.Services.Interfaces
{
    public interface ITileService
    {
        IEnumerable<Tile> GetTiles();
    }
}