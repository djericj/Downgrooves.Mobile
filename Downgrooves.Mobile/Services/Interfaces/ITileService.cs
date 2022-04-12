using Downgrooves.Mobile.ViewModels;
using System.Collections.Generic;

namespace Downgrooves.Mobile.Services.Interfaces
{
    public interface ITileService
    {
        IEnumerable<TileViewModel> GetTiles();
    }
}