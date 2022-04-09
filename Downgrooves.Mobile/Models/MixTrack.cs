namespace Downgrooves.Mobile.Models
{
    public class MixTrack
    {
        private string _title;
        private string _remix;

        public string Artist { get; set; }
        public string Label { get; set; }
        public int MixId { get; set; }
        public int MixTrackId { get; set; }
        public int Number { get; set; }
        public string Remix { get => _remix; set => _remix = value; }
        public string Title { get => _title; set => _title = value; }
        public int TrackId { get; set; }

        public string TitleAndMix
        {
            get => !string.IsNullOrEmpty(_remix) ? _title += $" ({_remix})" : _title;
        }

        public string RemixFormatted
        {
            get => !string.IsNullOrEmpty(_remix) ? $"({_remix})" : string.Empty;
        }
    }
}