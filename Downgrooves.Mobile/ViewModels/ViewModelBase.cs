using Prism.Mvvm;
using Prism.Navigation;
using System;
using Xamarin.Essentials;

namespace Downgrooves.Mobile.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void Initialize(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public virtual void Destroy()
        {
        }

        public async void OpenLink(string url)
        {
            var uri = new Uri(url);
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

        public async void GoBack()
        {
            await NavigationService.GoBackAsync();
        }
    }
}