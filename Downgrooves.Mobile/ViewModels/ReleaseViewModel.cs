using Downgrooves.Mobile.Models;
using System;
using System.Collections.Generic;

namespace Downgrooves.Mobile.ViewModels
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

        public int? Id
        {
            get => Release.Id;
            set => Release.Id = value;
        }

        public string WrapperType
        {
            get => Release.WrapperType;
            set => Release.WrapperType = value;
        }

        public string Kind
        {
            get => Release.Kind;
            set => Release.Kind = value;
        }

        public int ArtistId
        {
            get => Release.ArtistId;
            set => Release.ArtistId = value;
        }

        public int CollectionId
        {
            get => Release.CollectionId;
            set => Release.CollectionId = value;
        }

        public int TrackId
        {
            get => Release.TrackId;
            set => Release.TrackId = value;
        }

        public string ArtistName
        {
            get => Release.ArtistName;
            set => Release.ArtistName = value;
        }

        public string CollectionName
        {
            get => Release.CollectionName;
            set => Release.CollectionName = value;
        }

        public string TrackName
        {
            get => Release.TrackName;
            set => Release.TrackName = value;
        }

        public string CollectionCensoredName
        {
            get => Release.CollectionCensoredName;
            set => Release.CollectionCensoredName = value;
        }

        public string TrackCensoredName
        {
            get => Release.TrackCensoredName;
            set => Release.TrackCensoredName = value;
        }

        public string ArtistViewUrl
        {
            get => Release.ArtistViewUrl;
            set => Release.ArtistViewUrl = value;
        }

        public string CollectionViewUrl
        {
            get => Release.CollectionViewUrl;
            set => Release.CollectionViewUrl = value;
        }

        public string TrackViewUrl
        {
            get => Release.TrackViewUrl;
            set => Release.TrackViewUrl = value;
        }

        public string PreviewUrl
        {
            get => Release.PreviewUrl;
            set => Release.PreviewUrl = value;
        }

        public string ArtworkUrl30
        {
            get => Release.ArtworkUrl30;
            set => Release.ArtworkUrl30 = value;
        }

        public string ArtworkUrl60
        {
            get => Release.ArtworkUrl60;
            set => Release.ArtworkUrl60 = value;
        }

        public string ArtworkUrl100
        {
            get => Release.ArtworkUrl100;
            set => Release.ArtworkUrl100 = value;
        }

        public string ArtworkUrl250
        {
            get => Release.ArtworkUrl250;
        }

        public string ArtworkUrl500
        {
            get => Release.ArtworkUrl500;
        }

        public double CollectionPrice
        {
            get => Release.CollectionPrice;
            set => Release.CollectionPrice = value;
        }

        public double TrackPrice
        {
            get => Release.TrackPrice;
            set => Release.TrackPrice = value;
        }

        public DateTime ReleaseDate
        {
            get => Release.ReleaseDate;
            set => Release.ReleaseDate = value;
        }

        public string CollectionExplicitness
        {
            get => Release.CollectionExplicitness;
            set => Release.CollectionExplicitness = value;
        }

        public string TrackExplicitness
        {
            get => Release.TrackExplicitness;
            set => Release.TrackExplicitness = value;
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

        public int TrackCount
        {
            get => Release.TrackCount;
            set => Release.TrackCount = value;
        }

        public int TrackNumber
        {
            get => Release.TrackNumber;
            set => Release.TrackNumber = value;
        }

        public int TrackTimeMillis
        {
            get => Release.TrackTimeMillis;
            set => Release.TrackTimeMillis = value;
        }

        public string Country
        {
            get => Release.Country;
            set => Release.Country = value;
        }

        public string Currency
        {
            get => Release.Currency;
            set => Release.Currency = value;
        }

        public string PrimaryGenreName
        {
            get => Release.PrimaryGenreName;
            set => Release.PrimaryGenreName = value;
        }

        public string IsStreamable
        {
            get => Release.IsStreamable;
            set => Release.IsStreamable = value;
        }

        public IEnumerable<Release> Tracks { get; set; }
    }
}