using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.Services.Interfaces;
using MediaManager;
using MediaManager.Library;
using MediaManager.Player;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Diagnostics;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Downgrooves.Mobile.ViewModels
{
    public class MediaPlayerViewModel : ViewModelBase
    {
        private readonly IPlayerService _playerService;
        private string _playIcon;

        public IMediaItem CurrentTrack
        {
            get => CrossMediaManager.Current.Queue.Current;
        }

        public MediaPlayerState Status
        {
            get => CrossMediaManager.Current.State;
        }

        public string PlayIcon
        {
            get => _playIcon;
            set => SetProperty(ref _playIcon, value);
        }

        public MediaPlayerViewModel(IPlayerService playerService) : base(playerService)
        {
            _playerService = playerService;
            CrossMediaManager.Current.MediaItemChanged += (sender, args) => OnPropertyChanged(nameof(CurrentTrack));
                       
            CrossMediaManager.Current.StateChanged += (sender, args) =>
            {
                SetPlayIcon();
                OnPropertyChanged(nameof(Status));
            };

            PlayIcon = Fonts.FontAwesomeIcons.CirclePlay;
        }

        public ICommand FavoriteCommand => new RelayCommand(() => throw new NotImplementedException());
        public ICommand PlayPauseCommand => new RelayCommand(() =>
        {
            CrossMediaManager.Current.PlayPause();
        });

        public ICommand FastForwardCommand => new RelayCommand(() =>
        {
            CrossMediaManager.Current.PlayNext();
        });

        public override Task Load()
        {
            return null;
        }

        private void SetPlayIcon()
        {
            if (Status == MediaPlayerState.Playing)
                PlayIcon = Fonts.FontAwesomeIcons.CirclePause;
            else
                PlayIcon = Fonts.FontAwesomeIcons.CirclePlay;
        }


    }
}
