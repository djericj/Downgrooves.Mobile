using Downgrooves.Mobile.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.Services.Interfaces
{
    public interface IVideoService
    {
        Task<IEnumerable<Video>> GetVideosAsync(CancellationToken token = default);
    }
}