namespace Downgrooves.Mobile.Models
{
    public class ReleaseTrack
    {
        public string ArtistName { get; set; }
        public int Id { get; set; }
        public string PreviewUrl { get; set; }
        public double Price { get; set; }
        public int ReleaseId { get; set; }
        public string Title { get; set; }
        public int TrackId { get; set; }
        public int TrackNumber { get; set; }
        public int TrackTimeInMilliseconds { get; set; }
    }
}