using Downgrooves.Mobile.Models;
using System;
using System.Collections.Generic;

namespace Downgrooves.Mobile.ViewModels.Releases
{
    public class ReleaseViewModel
    {
        public Release Release { get; set; }

        public ReleaseViewModel() : this(new Release())
        {
        }

        public ReleaseViewModel(Release release)
        {
            Release = release;
        }

        public int CollectionId
        {
            get => Release.CollectionId;
            set => Release.CollectionId = value;
        }

        public Artist Artist
        {
            get => Release.Artist;
            set => Release.Artist = value;
        }

        public string ArtistName
        {
            get => Release.ArtistName;
            set => Release.ArtistName = value;
        }

        public string ArtistViewUrl
        {
            get => Release.ArtistViewUrl;
            set => Release.ArtistViewUrl = value;
        }

        public string ArtworkUrl
        {
            get => Release.ArtworkUrl;
            set => Release.ArtworkUrl = value;
        }

        public string BuyUrl
        {
            get => Release.BuyUrl;
            set => Release.BuyUrl = value;
        }

        public string Copyright
        {
            get => Release.Copyright;
            set => Release.Copyright = value;
        }

        public string Country
        {
            get => Release.Country;
            set => Release.Country = value;
        }

        public int DiscCount
        {
            get => Release.DiscCount;
            set => Release.DiscCount = value;
        }

        public int DiscNumber
        {
            get => Release.DiscNumber;
            set => Release.DiscNumber = value;
        }

        public string Genre
        {
            get => Release.Genre;
            set => Release.Genre = value;
        }

        public int Id
        {
            get => Release.Id;
            set => Release.Id = value;
        }

        public bool IsOriginal
        {
            get => Release.IsOriginal;
            set => Release.IsOriginal = value;
        }

        public bool IsRemix
        {
            get => Release.IsRemix;
            set => Release.IsRemix = value;
        }

        public string PreviewUrl
        {
            get => Release.PreviewUrl;
            set => Release.PreviewUrl = value;
        }

        public double Price
        {
            get => Release.Price;
            set => Release.Price = value;
        }

        public DateTime ReleaseDate
        {
            get => Release.ReleaseDate;
            set => Release.ReleaseDate = value;
        }

        public string Title
        {
            get => Release.Title;
            set => Release.Title = value;
        }

        public ICollection<ReleaseTrack> Tracks
        {
            get => Release.Tracks;
            set => Release.Tracks = value;
        }

        public int VendorId
        {
            get => Release.VendorId;
            set => Release.VendorId = value;
        }
    }
}