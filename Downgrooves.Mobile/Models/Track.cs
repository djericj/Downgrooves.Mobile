namespace Downgrooves.Mobile.Models
{
    public class Track
    {
        public int TrackId { get; set; }
        public int MixId { get; set; }
        public int Number { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Remix { get; set; }
        public string Label { get; set; }

        public string TitleAndMix
        {
            get
            {
                var name = Title;
                if (!string.IsNullOrEmpty(Remix)) name += $" ({Remix})";
                return name;
            }
        }

        public string RemixFormatted
        {
            get
            {
                if (!string.IsNullOrEmpty(Remix))
                    return $"({Remix})";
                return string.Empty;
            }
        }
    }
}
