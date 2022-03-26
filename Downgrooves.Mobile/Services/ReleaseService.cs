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
            var response = await GetAsync($"/itunes/tracks/paged?PageNumber={pageNumber}&PageSize={pageSize}", cancel: token);
            if (response.IsSuccessful)
            {
                IEnumerable<Release> releases = JsonConvert.DeserializeObject<List<Release>>(response.Content);
                var f = Convert(releases);
                return f;
            }
            else
            {
                Log.Fatal($"Http Exception {response.StatusCode}: {response.StatusDescription}");
            }
            return null;
        }

        private IEnumerable<ReleaseViewModel> Convert(IEnumerable<Release> releases)
        {
            return releases.ToList().Select(x => new ReleaseViewModel(x)).ToList();
        }
    }
}