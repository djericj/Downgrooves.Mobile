using Downgrooves.Mobile.Domain;
using Downgrooves.Mobile.ViewModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.Services.Interfaces
{
    public interface IMixService
    {
        Task<IEnumerable<MixViewModel>> GetMixesAsync(CancellationToken token = default);
        Task<IEnumerable<MixViewModel>> GetMixesAsync(int pageNumber, int pageSize, CancellationToken token = default);
        Task<IEnumerable<MixViewModel>> GetMixesAsync(string category, CancellationToken token = default);
        Task<IEnumerable<MixViewModel>> GetMixesAsync(Genre genre, CancellationToken token = default);

    }
}
