using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.ViewModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.Services.Interfaces
{
    public interface IReleaseService
    {
        Task<IEnumerable<ReleaseViewModel>> GetReleases(int pageNumber, int pageSize, CancellationToken token = default);
        Task<IEnumerable<Release>> Lookup(int collectionId, CancellationToken token = default);
    }
}