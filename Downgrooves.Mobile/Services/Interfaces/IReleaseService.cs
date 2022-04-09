using Downgrooves.Mobile.ViewModels.Releases;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.Services.Interfaces
{
    public interface IReleaseService
    {
        Task<IEnumerable<ReleaseViewModel>> GetReleases(int pageNumber, int pageSize, string artistName = null,
            int artistId = 0, bool isOriginal = false, bool isRemix = false, CancellationToken token = default);

        Task<ReleaseViewModel> GetRelease(int collectionId, CancellationToken token = default);
    }
}