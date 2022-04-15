using Downgrooves.Mobile.Controls;
using Downgrooves.Mobile.Models;
using Prism.Commands;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Downgrooves.Mobile.ViewModels.Releases
{
    public class ReleaseDetailViewModel : ViewModelBase
    {
        private Release _release;
        private Icon favoriteIcon;

        public ICommand OpenLinkCommand => new DelegateCommand<string>(async (link) =>
           {
               await OpenLink(link);
           });

        public ICommand GoBackCommand => new DelegateCommand(async () =>
          {
              await GoBack();
          });

        public ICommand FavoriteCommand => new DelegateCommand<Release>(Favorite);

        public Release Release
        {
            get => _release;
            set
            {
                _release = value;
                RaisePropertyChanged(nameof(Release));
            }
        }

        public Icon FavoriteIcon
        {
            get => favoriteIcon;
            set
            {
                favoriteIcon = value;
                RaisePropertyChanged(nameof(FavoriteIcon));
            }
        }

        public ReleaseDetailViewModel(INavigationService navigationService) : base(navigationService)
        {
            FavoriteIcon = Icon.HeartOutline;
        }

        public async void Favorite(Release release)
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

            if (_release == null)
                Release = parameters["release"] as Release;
        }
    }
}