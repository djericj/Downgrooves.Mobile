using Downgrooves.Mobile.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.Services.Interfaces
{
    public interface IMixService
    {
        Task<IEnumerable<Mix>> GetMixesAsync(CancellationToken token = default);

        Task<IEnumerable<Mix>> GetMixesAsync(int pageNumber, int pageSize, CancellationToken token = default);

        Task<IEnumerable<Mix>> GetMixesAsync(string category, CancellationToken token = default);

        Task<IEnumerable<Mix>> GetMixesAsync(Genre genre, CancellationToken token = default);

        Task<Mix> GetMixAsync(int mixId, CancellationToken token = default);
    }
}