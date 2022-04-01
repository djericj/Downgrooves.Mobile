using Downgrooves.Mobile.ViewModels;
using System.Collections.Generic;

namespace Downgrooves.Mobile
{
    public class AppSettings
    {
        public Website Website { get; set; }
        public MobileApi MobileApi { get; set; }
        public ListSettings MixSettings { get; set; }
        public ListSettings ReleaseSettings { get; set; }
        public ListSettings ModularSettings { get; set; }
        public TileSettings TileSettings { get; set; }
    }

    public class MobileApi
    {
        public string Url { get; set; }
        public string Token { get; set; }
    }

    public class Website
    {
        public string BaseUrl { get; set; }
        public string AudioFilePath { get; set; }
        public string ImagePath { get; set; }
    }

    public class TileSettings
    {
        public ICollection<TileViewModel> Tiles { get; set; }
    }

    public class ListSettings
    {
        public int ItemThreshold { get; set; }
        public int PageSize { get; set; }
    }
}
