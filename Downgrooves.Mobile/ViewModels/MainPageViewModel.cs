using Prism.Navigation;
using System;
using Xamarin.Forms;

namespace Downgrooves.Mobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase, INavigationAware
    {
        private bool _isActive;
        private ContentPage _currentPage;

        public ContentPage CurrentPage { get => _currentPage; set => _currentPage = value; }
        public string BackgroundImage => "resource://Downgrooves.Mobile.Resources.images.pavel-pjatakov-rywx3yUFaa0-unsplash.jpg";

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public event EventHandler IsActiveChanged;

        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value, RaiseIsActiveChanged); }
        }

        protected virtual void RaiseIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}