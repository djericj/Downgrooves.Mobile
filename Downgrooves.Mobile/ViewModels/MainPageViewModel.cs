using Prism.Commands;
using Prism.Navigation;
using System.Windows.Input;

namespace Downgrooves.Mobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            _navigationService = navigationService;
        }

        public ICommand NavigateToMixesCommand => new DelegateCommand<MixesViewModel>(async mix =>
        {
            await _navigationService.NavigateAsync("Mixes");
        });
    }
}
