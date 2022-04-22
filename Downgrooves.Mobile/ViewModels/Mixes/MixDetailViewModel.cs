using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.Services.Interfaces;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Downgrooves.Mobile.ViewModels.Mixes
{
    public class MixDetailViewModel : ViewModelBase
    {
        private Mix _mix;
        private string _favoriteIcon;

        public ICommand OpenLinkCommand => new RelayCommand<string>(async (link) =>
         {
             await OpenLink(link);
         });

        public ICommand GoBackCommand => new RelayCommand(async () =>
         {
             await GoBack();
         });

        public ICommand FavoriteCommand => new RelayCommand<Mix>(Favorite);

        public string FavoriteIcon
        {
            get => _favoriteIcon;
            set => SetProperty(ref _favoriteIcon, value);
        }

        public Mix Mix
        {
            get => _mix;
            set => SetProperty(ref _mix, value);    
        }

        public MixDetailViewModel(INavigationService navigationService) : base(navigationService)
        {
            FavoriteIcon = Fonts.FontAwesomeIcons.Heart;
            Task.Run(() => Load());
        }

        public override Task Load()
        {
            return null;            
        }

        public async void Favorite(Mix mix)
        {
            await Task.Run(() =>
            {
                if (FavoriteIcon == Fonts.FontAwesomeIcons.HeartPulse)
                    FavoriteIcon = Fonts.FontAwesomeIcons.Heart;
                else
                    FavoriteIcon = Fonts.FontAwesomeIcons.HeartPulse;
            });
        }

        
    }
}