namespace Downgrooves.Mobile.Domain
{
    public class Thumbnail
    {
        public int ThumbnailId { get; set; }
        public string VideoId { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}