using Prism.Navigation;

namespace Downgrooves.Mobile.ViewModels.Mixes
{
    public class MixDetailViewModel : ViewModelBase
    {
        private MixViewModel _mix;

        public MixViewModel Mix
        {
            get => _mix;
            set
            {
                _mix = value;
                RaisePropertyChanged(nameof(Mix));
            }
        }

        public MixDetailViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (_mix != null) return; // mix is already loaded.

            Mix = parameters["mix"] as MixViewModel;
        }
    }
}