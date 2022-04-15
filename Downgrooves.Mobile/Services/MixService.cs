using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.Services.Interfaces;
using Newtonsoft.Json;
using Serilog;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.Services
{
    public class MixService : ApiServiceBase, IMixService
    {
        public async Task<IEnumerable<Mix>> GetMixesAsync(CancellationToken token = default)
        {
            var response = await GetAsync("/mixes", cancel: token);
            if (response.IsSuccessful)
                return JsonConvert.DeserializeObject<List<Mix>>(response.Content);
            else
                Log.Fatal($"Http Exception {response.StatusCode}: {response.StatusDescription}");
            return null;
        }

        public async Task<IEnumerable<Mix>> GetMixesAsync(int pageNumber, int pageSize, CancellationToken token = default)
        {
            var response = await GetAsync($"/mixes/paged?PageNumber={pageNumber}&PageSize={pageSize}", cancel: token);
            if (response.IsSuccessful)
                return JsonConvert.DeserializeObject<List<Mix>>(response.Content);
            else
                Log.Fatal($"Http Exception {response.StatusCode}: {response.StatusDescription}");
            return null;
        }

        public async Task<IEnumerable<Mix>> GetMixesAsync(string category, CancellationToken token = default)
        {
            var content = await GetAsync($"/mixes/category/{category}", token);
            return JsonConvert.DeserializeObject<List<Mix>>(content.Content);
        }

        public async Task<IEnumerable<Mix>> GetMixesAsync(Genre genre, CancellationToken token = default)
        {
            var content = await GetAsync($"/mixes/genre/{genre.Name}", token);
            return JsonConvert.DeserializeObject<List<Mix>>(content.Content);
        }
    }
}