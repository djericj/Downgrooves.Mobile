using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Downgrooves.Mobile.Models
{
    public class Mix
    {
        public string Artist { get; set; }

        public string ArtworkUrl { get; set; }
        public string Category { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        [JsonProperty("mixId")]
        public int Id { get; set; }
        public string Length { get; set; }
        public string AudioUrl { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public int Show { get; set; }
        public int TotalPlays { get; set; }
        public ICollection<MixTrack> Tracks { get; set; }
    }
}