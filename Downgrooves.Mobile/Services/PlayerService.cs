using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.Services.Interfaces;
using System.Threading.Tasks;
using MediaManager;
using MediaManager.Library;

namespace Downgrooves.Mobile.Services
{
    public class PlayerService : IPlayerService
    {
        private bool _isPlayerVisible;

        public bool IsPlayerVisible
        {
            get => _isPlayerVisible;
            set => _isPlayerVisible = value;
        }

        public PlayerService()
        {
            CrossMediaManager.Current.ClearQueueOnPlay = true;
            CrossMediaManager.Current.StateChanged += (sender, args) =>
            {
                if (!IsPlayerVisible && args.State == MediaManager.Player.MediaPlayerState.Playing)
                    IsPlayerVisible = true;
            };
        }

        public MediaItem Create(Release release, ReleaseTrack track)
        {
            return new MediaItem()
            {
                Artist = track.ArtistName,
                AlbumImageUri = release.ArtworkUrl,
                DisplayImageUri = release.ArtworkUrl,
                ImageUri = release.ArtworkUrl,
                MediaUri = track.PreviewUrl,
                Title = track.Title
            };
        }

        public MediaItem Create(Mix mix)
        {
            return new MediaItem()
            {
                Artist = mix.Artist,
                AlbumImageUri = mix.ArtworkUrl,
                DisplayImageUri = mix.ArtworkUrl,
                ImageUri = mix.ArtworkUrl,
                MediaUri = mix.AudioUrl,
                Title = mix.Title
            };
        }

        public async Task Pause() => await CrossMediaManager.Current.Pause();
        public async Task Play() => await CrossMediaManager.Current.Play();
        public async Task Play(MediaItem mediaItem) => await CrossMediaManager.Current.Play(mediaItem);
        public async Task PlayPause() => await CrossMediaManager.Current.PlayPause();
        public async Task Stop() => await CrossMediaManager.Current.Stop();
        public async Task Start(Release release, ReleaseTrack track)
        {
            await Stop();
            var mediaItem = Create(release, track);
            await Play(mediaItem);
        }
        public async Task Start(Mix mix) 
        {
            await Stop();
            
            var mediaItem = Create(mix);
            await Play(mediaItem); 
        }
    }
}
