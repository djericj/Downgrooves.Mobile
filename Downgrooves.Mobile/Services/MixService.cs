using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.Services.Interfaces;
using Downgrooves.Mobile.ViewModels;
using Newtonsoft.Json;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.Services
{

    public class MixService : ApiServiceBase, IMixService
    {
        public async Task<IEnumerable<MixViewModel>> GetMixesAsync(CancellationToken token = default)
        {
            var response = await GetAsync("/mixes", cancel: token);
            if (response.IsSuccessful)
            {
                IEnumerable<Mix> mixes = JsonConvert.DeserializeObject<List<Mix>>(response.Content);
                var f = Convert(mixes);
                return f;
            }
            else
            {
                Log.Fatal($"Http Exception {response.StatusCode}: {response.StatusDescription}");
            }
            return null;
            
        }

        public async Task<IEnumerable<MixViewModel>> GetMixesAsync(int pageNumber, int pageSize, CancellationToken token = default)
        {
            var response = await GetAsync($"/mixes/paged?PageNumber={pageNumber}&PageSize={pageSize}", cancel: token);
            if (response.IsSuccessful)
            {
                IEnumerable<Mix> mixes = JsonConvert.DeserializeObject<List<Mix>>(response.Content);
                var f = Convert(mixes);
                return f;
            }
            else
            {
                Log.Fatal($"Http Exception {response.StatusCode}: {response.StatusDescription}");
            }
            return null;

        }

        public async Task<IEnumerable<MixViewModel>> GetMixesAsync(string category, CancellationToken token = default)
        {
            var content = await GetAsync($"/mixes/category/{category}", token);
            List<Mix> response = JsonConvert.DeserializeObject<List<Mix>>(content.Content);
            return Convert(response);
        }

        public async Task<IEnumerable<MixViewModel>> GetMixesAsync(Genre genre, CancellationToken token = default)
        {
            var content = await GetAsync($"/mixes/genre/{genre.Name}", token);
            List<Mix> response = JsonConvert.DeserializeObject<List<Mix>>(content.Content);
            return Convert(response);
        }

        private IEnumerable<MixViewModel> Convert(IEnumerable<Mix> mixes)
        {
            return mixes.ToList().Select(x => new MixViewModel(x)).ToList();
        }
    }
}
