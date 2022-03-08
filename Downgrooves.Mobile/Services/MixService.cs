using Downgrooves.Mobile.ApiEndpoints;
using Downgrooves.Mobile.Domain;
using Downgrooves.Mobile.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.Services
{
    public interface IMixService
    {
        Task<IEnumerable<MixViewModel>> GetMixVieModelsAsync(CancellationToken token = default);
        Task<IEnumerable<MixViewModel>> GetMixVieModelsAsync(string category, CancellationToken token = default);
        Task<IEnumerable<MixViewModel>> GetMixVieModelsAsync(Genre genre, CancellationToken token = default);
        
    }
    public class MixService : IMixService
    {
        private readonly IMixEndpoint _mixEndpoint;

        public MixService(IMixEndpoint mixEndpoint)
        {
            _mixEndpoint = mixEndpoint;
        }

        public async Task<IEnumerable<MixViewModel>> GetMixVieModelsAsync(CancellationToken token = default)
        {
            var content = await _mixEndpoint.GetMixesAsync(token);
            return content.ToList().Select(x => new MixViewModel(x)).ToList();
        }

        public async Task<IEnumerable<MixViewModel>> GetMixVieModelsAsync(string category, CancellationToken token = default)
        {
            var content = await _mixEndpoint.GetMixesByCategoryAsync(category, token);
            return content.ToList().Select(x => new MixViewModel(x)).ToList();
        }

        public async Task<IEnumerable<MixViewModel>> GetMixVieModelsAsync(Genre genre, CancellationToken token = default)
        {
            var content = await _mixEndpoint.GetMixesByGenreAsync(genre.Name, token);
            return content.ToList().Select(x => new MixViewModel(x)).ToList();
        }

    }
}
