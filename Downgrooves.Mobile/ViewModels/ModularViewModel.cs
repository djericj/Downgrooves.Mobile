using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.Services.Interfaces;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Downgrooves.Mobile.ViewModels
{
    public class ModularViewModel : ViewModelBase
    {
        private readonly IVideoService _videoService;
        private IEnumerable<Video> _videos;
        private bool _isBusy;
        private bool _isRefreshing;

        public ModularViewModel(INavigationService navigationService, IVideoService videoService) : base(navigationService)
        {
            _videoService = videoService;
        }

        public ICommand NavigateToVideoCommand => new RelayCommand<Video>(async (video) =>
           {
               await OpenLink(video.VideoUrl);
           });

        public ICommand RefreshCommand => new RelayCommand(async () =>
              {
                  IsRefreshing = true;
                  try
                  {
                      Videos = await LoadVideos();
                  }
                  catch (System.Exception ex)
                  {
                      Debug.WriteLine(ex.Message);
                      Debug.WriteLine(ex.StackTrace);
                  }
                  finally
                  {
                      IsRefreshing = false;
                  }
              });

        private async void ModularViewModel_IsActiveChanged(object sender, System.EventArgs e)
        {
            IsBusy = true;
            Videos = await LoadVideos();
            IsBusy = false;
        }

        public IEnumerable<Video> Videos
        {
            get => _videos;
            set { SetProperty(ref _videos, value); }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public async Task<IEnumerable<Video>> LoadVideos()
        {
            return await _videoService.GetVideosAsync();
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); Debug.WriteLine($"IsRefreshing: {IsRefreshing}"); }
        }
    }
}