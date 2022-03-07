using Downgrooves.Mobile.ApiEndpoints;
using Downgrooves.Mobile.Domain;
using Downgrooves.Mobile.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.Services
{
    public class MixService : IMixService
    {
        private readonly IMixEndpoint _mixEndpoint;

        public MixService(IMixEndpoint mixEndpoint)
        {
            _mixEndpoint = mixEndpoint;
        }

        public async Task<IEnumerable<Mix>> GetMixesAsync(CancellationToken token = default)
        {
            var content = await _mixEndpoint.GetMixesAsync(token);
            return content;
        }

        public async Task<IEnumerable<Mix>> GetMixesByCategoryAsync(string category, CancellationToken token = default)
        {
            var content = await _mixEndpoint.GetMixesByCategoryAsync(category, token);
            return content;
        }

        public async Task<IEnumerable<Mix>> GetMixesByGenreAsync(string genre, CancellationToken token = default)
        {
            var content = await _mixEndpoint.GetMixesByGenreAsync(genre, token);
            return content;
        }
    }
}
