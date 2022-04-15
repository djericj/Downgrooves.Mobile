using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.ViewModels.Releases;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.Services.Interfaces
{
    public interface IReleaseService
    {
        Task<IEnumerable<Release>> GetReleases(int pageNumber, int pageSize, string artistName = null,
            int artistId = 0, bool originals = false, bool remixes = false, CancellationToken token = default);

        Task<Release> GetRelease(int collectionId, CancellationToken token = default);
    }
}