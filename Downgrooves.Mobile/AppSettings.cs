namespace Downgrooves.Mobile
{
    public class AppSettings
    {
        public Website Website { get; set; }
        public MobileApi MobileApi { get; set; }        
    }

    public class MobileApi
    {
        public string Url { get; set; }
        public string Token { get; set; }
    }

    public class Website
    {
        public string BaseUrl { get; set; }
        public string AssetPath { get; set; }
        public string ImagePath { get; set; }
    }
}
