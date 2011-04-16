using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPhotoBlog.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Filename { get; set; }
        public string Camera { get; set; }
        public string Lens { get; set; }
        public string Aperture { get; set; }
        public string Exposure { get; set; }
        public string ISO { get; set; }
        public DateTime DatePosted { get; set; }
        public bool Published { get; set; }
        public DateTime? DatePublished { get; set; }
    }
}