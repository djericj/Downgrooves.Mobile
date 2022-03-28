﻿using System;
using System.Collections.Generic;

namespace Downgrooves.Mobile.Models
{
    public class Mix
    {
        public int MixId { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Length { get; set; }
        public string ShortDescription { get; set; }
        public string Mp3File { get; set; }
        public string Attachment { get; set; }
        public DateTime CreateDate { get; set; }
        public string Category { get; set; }
        public int TotalPlays { get; set; }
        public int Show { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}