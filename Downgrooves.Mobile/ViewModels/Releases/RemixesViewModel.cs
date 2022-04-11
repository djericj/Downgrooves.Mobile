using Downgrooves.Mobile.Services.Interfaces;
using Prism.Navigation;

namespace Downgrooves.Mobile.ViewModels.Releases
{
    public class RemixesViewModel : ReleasesViewModel
    {
        public RemixesViewModel(INavigationService navigationService, IReleaseService releaseService) : base(navigationService, releaseService)
        {
        }
    }
}