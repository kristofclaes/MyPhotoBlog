using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPhotoBlog.Models
{
    public class YearlyArchives
    {
        public List<Photo> Photos { get; set; }
        public int Year { get; set; }

        public YearlyArchives()
        {
            Photos = new List<Photo>();
        }
    }
}