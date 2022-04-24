﻿using System;
using System.Collections.Generic;

namespace Downgrooves.Mobile.Models
{
    public class Release
    {
        public int CollectionId { get; set; }
        public Artist Artist { get; set; }
        public string ArtistName { get; set; }
        public string ArtistViewUrl { get; set; }
        public string ArtworkUrl { get; set; }
        public string BuyUrl { get; set; }
        public string Copyright { get; set; }
        public string Country { get; set; }
        public int DiscCount { get; set; }
        public int DiscNumber { get; set; }
        public string Genre { get; set; }
        public int Id { get; set; }
        public bool IsOriginal { get; set; }
        public bool IsRemix { get; set; }
        public string PreviewUrl { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleaseId { get; set; }
        public string Title { get; set; }
        public int TrackId { get; set; }
        public int TrackNumber { get; set; }
        public int TrackTimeInMilliseconds { get; set; }
        public ICollection<ReleaseTrack> Tracks { get; set; }
        public int VendorId { get; set; }
    }
}