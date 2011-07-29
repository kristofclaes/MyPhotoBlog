using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPhotoBlog.Models
{
    public class MonthlyArchives
    {
        public string Month { get; set; }
        public List<Photo> Photos { get; set; }

        public MonthlyArchives()
        {
            Photos = new List<Photo>();
        }
    }
}