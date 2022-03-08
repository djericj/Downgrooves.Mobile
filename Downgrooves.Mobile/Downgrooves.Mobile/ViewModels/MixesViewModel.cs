using Downgrooves.Mobile.Services;
using Prism.Navigation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.ViewModels
{
    public class MixesViewModel : INavigationAware
    {
        private readonly IMixService _mixService;
        public IEnumerable<MixViewModel> Mixes { get; set; }

        public MixesViewModel(IMixService mixService)
        {
            _mixService = mixService;
        }

        public void LoadMixes() => Mixes = Task.Run(async () => await _mixService.GetMixVieModelsAsync()).Result;

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            LoadMixes();
        }
    }
}
