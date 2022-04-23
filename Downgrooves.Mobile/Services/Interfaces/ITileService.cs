using Downgrooves.Mobile.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.Services.Interfaces
{
    public interface ITileService
    {
        Task<IEnumerable<Tile>> GetTiles();
    }
}