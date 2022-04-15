using Downgrooves.Mobile.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.Services.Interfaces
{
    public interface IArtistService
    {
        Task<IEnumerable<Artist>> GetArtists(CancellationToken token = default);

        Task<Artist> GetArtist(int id);

        Task<Artist> GetArtist(string name);
    }
}