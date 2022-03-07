using Downgrooves.Mobile.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.Interfaces
{
    public interface IMixService
    {
        Task<IEnumerable<Mix>> GetMixesAsync(CancellationToken token = default);

        Task<IEnumerable<Mix>> GetMixesByCategoryAsync(string category, CancellationToken token = default);

        Task<IEnumerable<Mix>> GetMixesByGenreAsync(string genre, CancellationToken token = default);
    }
}
