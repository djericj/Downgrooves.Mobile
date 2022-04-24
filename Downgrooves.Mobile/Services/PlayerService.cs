using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.Services
{
    public class PlayerService : IPlayerService
    {
        public PlayerTrack Create(Release release)
        {
            return new PlayerTrack()
            {
                Artist = release.Artist.Name,
                ArtworkUrl = release.ArtworkUrl,
                AudioUrl = release.PreviewUrl,
                Title = release.Title
            };
        }

        public PlayerTrack Create(Mix mix)
        {
            return new PlayerTrack()
            {
                Artist = mix.Artist,
                ArtworkUrl = mix.ArtworkUrl,
                AudioUrl = mix.AudioUrl,
                Title = mix.Title
            };
        }

        public async Task Pause()
        {
            throw new NotImplementedException();
        }

        public async Task Play(string url)
        {
            throw new NotImplementedException();
        }

        public async Task Play(Release release) => await Play(release.PreviewUrl);
        

        public async Task Play(Mix mix) => await Play(mix.AudioUrl);
        

        public async Task Stop()
        {
            throw new NotImplementedException();
        }
    }
}
