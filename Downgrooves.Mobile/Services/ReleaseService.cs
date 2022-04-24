using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.Services.Interfaces;
using Newtonsoft.Json;
using Serilog;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.Services
{
    public class ReleaseService : ApiServiceBase, IReleaseService
    {
        public async Task<IEnumerable<Release>> GetReleases(int pageNumber, int pageSize, string artistName = null,
            int artistId = 0, bool originals = false, bool remixes = false, CancellationToken token = default)
        {
            var resource = $"/releases/paged?pageNumber={pageNumber}&pageSize={pageSize}";
            if (artistName != null) resource += $"&artistName={artistName}";
            if (artistId > 0) resource += $"&artistId={artistId}";
            if (originals) resource += $"&isOriginal=true";
            if (remixes) resource += $"&isRemix=true";

            var response = await GetAsync(resource, cancel: token);
            if (response.IsSuccessful)
                return JsonConvert.DeserializeObject<List<Release>>(response.Content);
            else
                Log.Fatal($"Http Exception {response.StatusCode}: {response.StatusDescription} {response.ErrorMessage}");
            return null;
        }

        public async Task<Release> GetRelease(int collectionId, CancellationToken token = default)
        {
            try
            {
                var response = await GetAsync($"/release/collection/{collectionId}", cancel: token);
                if (response.IsSuccessful)
                    return JsonConvert.DeserializeObject<Release>(response.Content);
                else
                    Log.Fatal($"Http Exception {response.StatusCode}: {response.StatusDescription} {response.ErrorMessage}");
                
            }
            catch (System.Exception ex)
            {
                Log.Fatal(ex.Message);
                Log.Fatal(ex.StackTrace);
                throw;
            }
            return null;
        }
    }
}