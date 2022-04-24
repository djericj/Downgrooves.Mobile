using Downgrooves.Mobile.Services.Interfaces;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Downgrooves.Mobile.ViewModels
{
    public class MediaPlayerViewModel : ViewModelBase
    {
        public MediaPlayerViewModel(IPlayerService playerService) : base(playerService)
        {
            Task.Run(() => Load());
        }

        public ICommand FavoriteCommand => new RelayCommand(() => throw new NotImplementedException());
        public ICommand PlayCommand => new RelayCommand(() => throw new NotImplementedException());
        public ICommand FastForwardCommand => new RelayCommand(() => throw new NotImplementedException());

        public override Task Load()
        {
            return null;
        }
    }
}
