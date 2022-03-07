using Downgrooves.Mobile.Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.ApiEndpoints
{
    public interface IMixEndpoint
    {
        Task<IEnumerable<Mix>> GetMixesAsync(CancellationToken token = default);

        Task<IEnumerable<Mix>> GetMixesByCategoryAsync(string category, CancellationToken token = default);

        Task<IEnumerable<Mix>> GetMixesByGenreAsync(string genre, CancellationToken token = default);

    }

    internal class MixEndpoint : BaseEndpoint, IMixEndpoint
    {
        public async Task<IEnumerable<Mix>> GetMixesAsync(CancellationToken token = default)
        {
            var content = await GetAsync("/mixes", cancel:token);
            List<Mix> response = JsonConvert.DeserializeObject<List<Mix>>(content.Content);
            return response;
        }

        public async Task<IEnumerable<Mix>> GetMixesByCategoryAsync(string category, CancellationToken token = default)
        {
            var content = await GetAsync($"/mixes/category/{category}", token);
            List<Mix> response = JsonConvert.DeserializeObject<List<Mix>>(content.Content);
            return response;
        }

        public async Task<IEnumerable<Mix>> GetMixesByGenreAsync(string genre, CancellationToken token = default)
        {
            var content = await GetAsync($"/mixes/genre/{genre}", token);
            List<Mix> response = JsonConvert.DeserializeObject<List<Mix>>(content.Content);
            return response;
        }
    }
}
