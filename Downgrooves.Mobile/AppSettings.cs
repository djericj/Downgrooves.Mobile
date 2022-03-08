namespace Downgrooves.Mobile
{
    public interface IAppSettings
    {
        MobileApi MobileApi { get; set; }
    }

    public class AppSettings : IAppSettings
    {
        public MobileApi MobileApi { get; set; }

        public AppSettings()
        {
            MobileApi = new MobileApi();
        }
    }

    public class MobileApi
    {
        public string Url { get; set; }
    }
}
