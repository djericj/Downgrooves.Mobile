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
    public class ReleaseService : ApiServiceBase, IReleaseService
    {
        public async Task<IEnumerable<ReleaseViewModel>> GetReleases(int pageNumber, int pageSize, CancellationToken token = default)
        {
            var response = await GetAsync($"/releases/paged?PageNumber={pageNumber}&PageSize={pageSize}", cancel: token);
            if (response.IsSuccessful)
            {
                IEnumerable<Release> releases = JsonConvert.DeserializeObject<List<Release>>(response.Content);
                var converted = releases.Select(x => new ReleaseViewModel(x)).ToList();
                return converted;
            }
            else
            {
                Log.Fatal($"Http Exception {response.StatusCode}: {response.StatusDescription}");
            }
            return null;
        }

        public async Task<IEnumerable<Release>> Lookup(int collectionId, CancellationToken token = default)
        {
            var response = await GetAsync($"/itunes/lookup/{collectionId}", cancel: token);
            if (response.IsSuccessful)
            {
                IEnumerable<Release> releases = JsonConvert.DeserializeObject<List<Release>>(response.Content);
                return releases?.OrderBy(x => x.TrackNumber);
            }
            else
            {
                Log.Fatal($"Http Exception {response.StatusCode}: {response.StatusDescription}");
            }
            return null;
        }
    }
}