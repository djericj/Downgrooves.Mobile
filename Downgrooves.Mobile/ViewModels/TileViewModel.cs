using Prism.Navigation;

namespace Downgrooves.Mobile.ViewModels
{
    public class TileViewModel
    {
        public string Title { get; set; }
        public string SvgIcon { get; set; }
        public string NavigateTo { get; set; }

        public NavigationParameters Parameters { get; set; }

        public string SvgIconAbsolutePath
        {
            get => $"resource://Downgrooves.Mobile.Resources.{SvgIcon}";
        }
    }
}