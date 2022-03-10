using Downgrooves.Mobile.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Downgrooves.Mobile.ViewModels
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

        public int MixId => Mix.MixId;
        public Genre Genre 
        {
            get => Mix.Genre;
            set => Mix.Genre = value;
        }
        public string Name 
        {
            get => Mix.Name;
            set => Mix.Name = value;
        }
        public string Artist
        {
            get => Mix.Artist;
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
        public string Mp3File
        {
            get => Mix.Mp3File;
            set => Mix.Mp3File = value;
        }
        public string Attachment
        {
            get => $"{App.Settings.Website.BaseUrl}/{App.Settings.Website.ImagePath}/mixes/{Mix.Attachment}";
            set => Mix.Attachment = value;
        }
        public DateTime CreateDate
        {
            get => Mix.CreateDate;
            set => Mix.CreateDate = value;
        }
        public string Category
        {
            get => Mix.Category;
            set => Mix.Category = value;
        }
        public int Show
        {
            get => Mix.Show;
            set => Mix.Show = value;
        }
        public ICollection<Track> Tracks
        {
            get => Mix.Tracks;
            set => Mix.Tracks = value;
        }
    }
}
