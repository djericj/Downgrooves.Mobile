using Downgrooves.Mobile.Controls;

namespace Downgrooves.Mobile.Models
{
    public class Tile
    {
        public string Title { get; set; }
        public Icon SvgIcon { get; set; }
        public string NavigateTo { get; set; }

        public string SvgIconAbsolutePath
        {
            get => $"resource://Downgrooves.Mobile.Resources.{SvgIcon}";
        }
    }
}