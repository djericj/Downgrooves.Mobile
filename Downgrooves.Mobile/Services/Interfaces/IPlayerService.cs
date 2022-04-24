using Downgrooves.Mobile.Models;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.Services.Interfaces
{
    public interface IPlayerService
    {
        Task Play(Release release);
        Task Play(Mix mix);
        Task Play(string url);
        Task Pause();
        Task Stop();
        PlayerTrack Create(Release release);
        PlayerTrack Create(Mix mix);
    }
}
