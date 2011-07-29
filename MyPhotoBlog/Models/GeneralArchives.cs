using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPhotoBlog.Models
{
    public class GeneralArchives
    {
        public List<YearInfo> Years { get; set; }

        public GeneralArchives()
        {
            Years = new List<YearInfo>();
        }
    }

    public class YearInfo
    {
        public int Year { get; set; }
        public int NumberOfPhotos { get; set; }
        public List<MonthInfo> Months { get; set; }

        public YearInfo()
        {
            Months = new List<MonthInfo>();
        }
    }

    public class MonthInfo
    {
        public int Month { get; set; }
        public string MonthName { get; set; }
        public int NumberOfPhotos { get; set; }
    }
}