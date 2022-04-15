using System;
using System.Collections.Generic;

namespace Downgrooves.Mobile.Models
{
    public class Thumbnail
    {
        public int ThumbnailId { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public Video Video { get; set; }
        public int VideoId { get; set; }
    }

    public class Video
    {
        public DateTime PublishedAt { get; set; }
        public IList<Thumbnail> Thumbnails { get; set; }
        public int Id { get; set; }
        public string Default { get; set; }
        public string Description { get; set; }
        public string ETag { get; set; }
        public string High { get; set; }
        public string MaxRes { get; set; }
        public string Medium { get; set; }
        public string SourceSystemId { get; set; }
        public string Standard { get; set; }
        public string Title { get; set; }
        public string VideoUrl { get; set; }
    }
}