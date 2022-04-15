using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.Services.Interfaces;
using Newtonsoft.Json;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.Services
{
    public class ArtistService : ApiServiceBase, IArtistService
    {
        private IEnumerable<Artist> _artists;

        public async Task<Artist> GetArtist(int id)
        {
            if (_artists == null)
                _artists = await GetArtists();
            return _artists.FirstOrDefault(x => x.ArtistId == id);
        }

        public async Task<Artist> GetArtist(string name)
        {
            if (_artists == null)
                _artists = await GetArtists();
            return _artists.FirstOrDefault(x => x.Name == name);
        }

        public async Task<IEnumerable<Artist>> GetArtists(CancellationToken token = default)
        {
            var response = await GetAsync("/artists", cancel: token);
            if (response.IsSuccessful)
                return JsonConvert.DeserializeObject<List<Artist>>(response.Content);
            else
                Log.Fatal($"Http Exception {response.StatusCode}: {response.StatusDescription}");
            return null;
        }
    }
}