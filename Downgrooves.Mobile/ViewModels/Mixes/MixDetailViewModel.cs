using Downgrooves.Mobile.Controls;
using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.Services.Interfaces;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Downgrooves.Mobile.ViewModels.Mixes
{
    public class MixDetailViewModel : ViewModelBase
    {
        private Mix _mix;
        private Icon _favoriteIcon;

        public ICommand OpenLinkCommand => new RelayCommand<string>(async (link) =>
         {
             throw new NotImplementedException();
         });

        public ICommand GoBackCommand => new RelayCommand(async () =>
         {
             throw new NotImplementedException();
         });

        public ICommand FavoriteCommand => new RelayCommand<Mix>(Favorite);

        public Icon FavoriteIcon
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
    }
}