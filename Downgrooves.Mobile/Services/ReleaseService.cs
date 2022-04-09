using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.Services.Interfaces;
using Downgrooves.Mobile.ViewModels.Releases;
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
        public async Task<IEnumerable<ReleaseViewModel>> GetReleases(int pageNumber, int pageSize, string artistName = null,
            int artistId = 0, bool isOriginal = false, bool isRemix = false, CancellationToken token = default)
        {
            var resource = $"/releases/paged?pageNumber={pageNumber}&pageSize={pageSize}";
            if (artistName != null) resource += $"&artistName={artistName}";
            if (artistId > 0) resource += $"&artistId={artistId}";
            if (isOriginal) resource += $"&isOriginal=true";
            if (isRemix) resource += $"&isRemix=true";

            var response = await GetAsync(resource, cancel: token);
            if (response.IsSuccessful)
            {
                IEnumerable<Release> releases = JsonConvert.DeserializeObject<List<Release>>(response.Content);
                var converted = releases.Select(x => new ReleaseViewModel(x)).ToList();
                return converted;
            }
            else
            {
                Log.Fatal($"Http Exception {response.StatusCode}: {response.StatusDescription} {response.ErrorMessage}");
            }
            return null;
        }

        public async Task<ReleaseViewModel> GetRelease(int collectionId, CancellationToken token = default)
        {
            var response = await GetAsync($"/releases/collection/{collectionId}", cancel: token);
            if (response.IsSuccessful)
            {
                Release release = JsonConvert.DeserializeObject<Release>(response.Content);
                return new ReleaseViewModel(release);
            }
            else
            {
                Log.Fatal($"Http Exception {response.StatusCode}: {response.StatusDescription} {response.ErrorMessage}");
            }
            return null;
        }
    }
}