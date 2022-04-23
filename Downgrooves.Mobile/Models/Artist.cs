using System.Collections.Generic;

namespace Downgrooves.Mobile.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Release> Releases { get; set; }
    }
}