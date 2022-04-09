using Downgrooves.Mobile.Models;
using System;
using System.Collections.Generic;

namespace Downgrooves.Mobile.ViewModels.Mixes
{
    public class MixViewModel
    {
        public Mix Mix { get; set; }

        public MixViewModel() : this(new Mix())
        {
        }

        public MixViewModel(Mix mix)
        {
            Mix = mix;
        }

        public int Id => Mix.Id;

        public Genre Genre
        {
            get => Mix.Genre;
            set => Mix.Genre = value;
        }

        public string Title
        {
            get => Mix.Title;
            set => Mix.Title = value;
        }

        public string Artist
        {
            get => $"mixed by {Mix.Artist}";
            set => Mix.Artist = value;
        }

        public string Length
        {
            get => Mix.Length;
            set => Mix.Length = value;
        }

        public string ShortDescription
        {
            get => Mix.ShortDescription;
            set => Mix.ShortDescription = value;
        }

        public string Description
        {
            get => Mix.Description;
            set => Mix.Description = value;
        }

        public string AudioUrl
        {
            get => Mix.AudioUrl;
            set => Mix.AudioUrl = value;
        }

        public string ArtworkUrl
        {
            get => Mix.ArtworkUrl;
            set => Mix.ArtworkUrl = value;
        }

        public DateTime CreateDate
        {
            get => Mix.CreateDate;
            set => Mix.CreateDate = value;
        }

        public ICollection<MixTrack> Tracks
        {
            get => Mix.Tracks;
            set => Mix.Tracks = value;
        }
    }
}