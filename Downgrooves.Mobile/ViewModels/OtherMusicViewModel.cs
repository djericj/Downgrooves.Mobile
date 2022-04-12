using Prism.Navigation;

namespace Downgrooves.Mobile.ViewModels
{
    public class OtherMusicViewModel : ViewModelBase
    {
        public OtherMusicViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }
    }
}