using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.Services.Interfaces;
using Microsoft.Toolkit.Mvvm.Input;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Downgrooves.Mobile.ViewModels.Releases
{
    public class ReleaseDetailViewModel : ViewModelBase
    {
        private Release _release;
        private string _favoriteIcon;

        public ICommand OpenLinkCommand => new RelayCommand<string>(async (link) =>
           {
               await OpenLink(link);
           });

        public ICommand GoBackCommand => new RelayCommand(async () =>
          {
              await GoBack();
          });

        public ICommand FavoriteCommand => new RelayCommand<Release>(Favorite);

        public Release Release
        {
            get => _release;
            set => SetProperty(ref _release, value);
        }

        public string FavoriteIcon
        {
            get => _favoriteIcon;
            set => SetProperty(ref _favoriteIcon, value);
        }

        public ReleaseDetailViewModel(INavigationService navigationService) : base(navigationService)
        {
            FavoriteIcon = Fonts.FontAwesomeIcons.Heart;
            Task.Run(() => Load());
        }

        public async override Task Load()
        {
            
        }

        public async void Favorite(Release release)
        {
            await Task.Run(() =>
            {
                if (FavoriteIcon == Fonts.FontAwesomeIcons.HeartCrack)
                    FavoriteIcon = Fonts.FontAwesomeIcons.Heart;
                else
                    FavoriteIcon = Fonts.FontAwesomeIcons.HeartCrack;
            });
        }

        
    }
}