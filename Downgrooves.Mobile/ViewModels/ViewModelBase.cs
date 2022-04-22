using Downgrooves.Mobile.Services.Interfaces;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Downgrooves.Mobile.ViewModels
{
    public class ViewModelBase : ObservableObject
    {

        private bool _isActive;
        private string _title;

        private readonly INavigationService _navigationService;

        private Dictionary<string, object> properties = new Dictionary<string, object>();

        public ViewModelBase(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

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