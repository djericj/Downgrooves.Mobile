using Downgrooves.Mobile.Models;
using MediaManager.Library;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.Services.Interfaces
{
    public interface IPlayerService
    {
        bool IsPlayerVisible { get; }
        Task Start(Release release, ReleaseTrack track);
        Task Start(Mix mix);
        Task Play();
        Task Play(MediaItem mediaItem);
        Task PlayPause();
        Task Pause();
        Task Stop();
        MediaItem Create(Release release, ReleaseTrack track);
        MediaItem Create(Mix mix);
    }
}
