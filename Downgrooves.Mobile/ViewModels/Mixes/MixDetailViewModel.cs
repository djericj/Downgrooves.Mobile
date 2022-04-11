using Downgrooves.Mobile.Controls;
using Downgrooves.Mobile.Models;
using Prism.Commands;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Downgrooves.Mobile.ViewModels.Mixes
{
    public class MixDetailViewModel : ViewModelBase
    {
        private MixViewModel _mix;
        private Icon favoriteIcon;

        public ICommand OpenLinkCommand => new DelegateCommand<string>(OpenLink);

        public ICommand GoBackCommand => new DelegateCommand(GoBack);

        public ICommand FavoriteCommand => new DelegateCommand<Mix>(Favorite);

        public Icon FavoriteIcon
        {
            get => favoriteIcon;
            set
            {
                favoriteIcon = value;
                RaisePropertyChanged(nameof(FavoriteIcon));
            }
        }

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
            FavoriteIcon = Icon.HeartOutline;
        }

        public async void Favorite(Mix mix)
        {
            await Task.Run(() =>
            {
                if (FavoriteIcon == Icon.HeartOutline)
                    FavoriteIcon = Icon.Heart;
                else
                    FavoriteIcon = Icon.HeartOutline;
            });
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (_mix != null) return; // mix is already loaded.

            Mix = parameters["mix"] as MixViewModel;
        }
    }
}