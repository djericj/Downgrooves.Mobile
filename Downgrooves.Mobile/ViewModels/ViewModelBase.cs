using Downgrooves.Mobile.Services.Interfaces;
using MediaManager;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Downgrooves.Mobile.ViewModels
{
    public abstract class ViewModelBase : ObservableObject, IViewModel
    {

        private bool _isActive;
        private string _title;
        private bool _isPlayerVisible;

        private readonly IPlayerService _playerService;

        private Dictionary<string, object> properties = new Dictionary<string, object>();
        
        public ViewModelBase(IPlayerService playerService)
        {
            _playerService = playerService;
            //IsPlayerVisible = playerService.IsPlayerVisible;
            IsPlayerVisible = true;
            OnPropertyChanged(nameof(IsPlayerVisible));
            CrossMediaManager.Current.StateChanged += (sender, args) =>
            {
                if (!IsPlayerVisible && args.State == MediaManager.Player.MediaPlayerState.Playing)
                    IsPlayerVisible = true;
                OnPropertyChanged(nameof(IsPlayerVisible));
            };
        }

        public abstract Task Load();

        public string Title
        {
            get { return _title; }
            set { SetProperty(_title, value); }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(value); }
        }

        public bool IsPlayerVisible 
        { 
            get => _isPlayerVisible; 
            set => SetProperty(ref _isPlayerVisible, value); 
        }

        public virtual void Destroy()
        {
        }

        public async Task OpenLink(string url)
        {
            var uri = new Uri(url);
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

        public async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        public async Task GoToAsync(string uri)
        {
            await Shell.Current.GoToAsync(uri);
        }

        protected void SetProperty<T>(T value, [CallerMemberName] string propertyName = null)
        {
            if (!properties.ContainsKey(propertyName))
            {
                properties.Add(propertyName, default(T));
            }

            var oldValue = GetProperty<T>(propertyName);
            if (!EqualityComparer<T>.Default.Equals(oldValue, value))
            {
                properties[propertyName] = value;
                OnPropertyChanged(propertyName);
            }
        }

        protected T GetProperty<T>([CallerMemberName] string propertyName = null)
        {
            if (!properties.ContainsKey(propertyName))
            {
                return default(T);
            }
            else
            {
                return (T)properties[propertyName];
            }
        }


    }
}