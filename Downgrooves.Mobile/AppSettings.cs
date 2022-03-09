namespace Downgrooves.Mobile
{
    public class AppSettings
    {
        public MobileApi MobileApi { get; set; }
    }

    public class MobileApi
    {
        public string Url { get; set; }
        public string Token { get; set; }
    }
}
