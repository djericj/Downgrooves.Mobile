using Downgrooves.Mobile.ViewModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.Services.Interfaces
{
    public interface IReleaseService
    {
        Task<IEnumerable<ReleaseViewModel>> GetReleases(int pageNumber, int pageSize, CancellationToken token = default);
    }
}