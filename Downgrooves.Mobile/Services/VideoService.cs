using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.Services.Interfaces;
using Newtonsoft.Json;
using Serilog;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.Services
{
    public class VideoService : ApiServiceBase, IVideoService
    {
        public async Task<IEnumerable<Video>> GetVideosAsync(CancellationToken token = default)
        {
            var response = await GetAsync("/videos", cancel: token);
            if (response.IsSuccessful)
                return JsonConvert.DeserializeObject<List<Video>>(response.Content);
            else
                Log.Fatal($"Http Exception {response.StatusCode}: {response.StatusDescription}");
            return null;
        }
    }
}