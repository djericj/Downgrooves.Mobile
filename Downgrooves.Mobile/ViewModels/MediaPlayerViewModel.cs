using Downgrooves.Mobile.Services.Interfaces;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.ViewModels
{
    public class MediaPlayerViewModel : ViewModelBase
    {
        public MediaPlayerViewModel(INavigationService navigationService) : base(navigationService)
        {
            Task.Run(() => Load());
        }

        public override Task Load()
        {
            return null;
        }
    }
}
