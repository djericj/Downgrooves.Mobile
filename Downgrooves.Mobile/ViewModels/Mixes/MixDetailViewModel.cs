using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.Services.Interfaces;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Downgrooves.Mobile.ViewModels.Mixes
{
    public class MixDetailViewModel : ViewModelBase, IQueryAttributable
    {
        private Mix _mix;
        private int _mixId;
        private bool _isFavorite;
        private readonly IPlayerService _playerService;
        private readonly IMixService _mixService;

        public MixDetailViewModel(IPlayerService playerService, IMixService mixService) : base(playerService)
        {
            _playerService = playerService;
            _mixService = mixService;
            Task.Run(() => Load());
        }

        public ICommand ListenCommand => new RelayCommand<Mix>(async (mix) => await _playerService.Start(mix));

        public ICommand GoBackCommand => new RelayCommand(async () => await GoBack());

        public ICommand FavoriteCommand => new RelayCommand<Mix>((mix) => IsFavorite = !IsFavorite);

        public Mix Mix
        {
            get => _mix;
            set => SetProperty(ref _mix, value);    
        }

        public int MixId
        {
            get => _mixId;
            set { SetProperty(ref _mixId, value); }
        }

        public bool IsFavorite
        {
            get => _isFavorite;
            set => SetProperty(ref _isFavorite, value);
        }

        public override Task Load()
        {
            return null;            
        }

        public async Task Load(int mixId)
        {
            Mix = await _mixService.GetMixAsync(mixId);
        }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            MixId = Convert.ToInt32(query["mixId"]);
            Task.Run(() => Load(MixId));
        }
    }
}