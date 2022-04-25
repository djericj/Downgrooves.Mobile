using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.Services.Interfaces;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using Xamarin.Forms;

namespace Downgrooves.Mobile.ViewModels.Releases
{
    public class ReleaseDetailViewModel : ViewModelBase, IQueryAttributable
    {
        private IPlayerService _playerService;
        private IReleaseService _releaseService;
        private Release _release;
        private string _favoriteIcon;
        private int _collectionId;
        private bool _isFavorite;

        public ReleaseDetailViewModel(IPlayerService playerService, IReleaseService releaseService) : base(playerService)
        {
            _releaseService = releaseService;
            _playerService = playerService;
        }

        public ICommand OpenLinkCommand => new RelayCommand<string>(async (link) =>
           {
               await OpenLink(link);
           });

        public ICommand GoBackCommand => new RelayCommand(async () =>
          {
              await GoBack();
          });

        public ICommand FavoriteCommand => new RelayCommand(() => IsFavorite = !IsFavorite);

        public ICommand PlayCommand => new RelayCommand<ReleaseTrack>(async (track) =>
        {
            await _playerService.Start(_release, track);
        });

        public int CollectionId
        {
            get => _collectionId;
            set { SetProperty(ref _collectionId, value); }
        }

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

        public bool IsFavorite 
        { 
            get => _isFavorite; 
            set => SetProperty(ref _isFavorite, value); 
        }

        public ReleaseDetailViewModel(IPlayerService playerService) : base(playerService)
        {
            FavoriteIcon = Fonts.FontAwesomeIcons.Heart;
            IsFavorite = false;
        }

        public async override Task Load() { }

        public async Task Load(int collectionId)
        {
            Release = await _releaseService.GetRelease(collectionId);
        }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            CollectionId = Convert.ToInt32(query["collectionId"]);
            Task.Run(() => Load(_collectionId));
        }
    }
}