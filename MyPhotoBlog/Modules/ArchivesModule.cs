using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyPhotoBlog.Models;
using MyPhotoBlog.Services;
using Simple.Data;

namespace MyPhotoBlog.Modules
{
    public class ArchivesModule : PhotoblogModule
    {
        public ArchivesModule(IDBFactory dbFactory)
            : base(dbFactory, "/archives")
        {
            Get[""] = parameters =>
            {
                List<DateTime> allDates = DB.Photos.Query().Select(DB.Photos.DatePublished).Where(DB.Photos.Published == true).OrderByDatePublishedDescending().ToScalarList<DateTime>();

                var model = new GeneralArchives
                                {
                                    Years = (from date in allDates
                                             group date by date.Year
                                             into yearGroup
                                             select new YearInfo
                                                        {
                                                            Year = yearGroup.Key,
                                                            NumberOfPhotos = yearGroup.Count(),
                                                            Months = (from yearDate in yearGroup
                                                                      group yearDate by yearDate.Month
                                                                      into monthGroup
                                                                      select new MonthInfo
                                                                                 {
                                                                                     Month = monthGroup.Key,
                                                                                     MonthName = monthGroup.First().ToString("MMMM"),
                                                                                     NumberOfPhotos = monthGroup.Count()
                                                                                 }).ToList()
                                                        }).ToList()
                                };

                return View["general-archives", model];
            };

            Get[@"/(?<year>19[0-9]{2}|2[0-9]{3})"] = parameters =>
            {
                int year = Convert.ToInt32((string)parameters.year);
                DateTime start = new DateTime(year, 1, 1);
                DateTime end = start.AddYears(1);

                List<Photo> photos = DB.Photos.FindAllByDatePublishedAndPublished(start.ToString("yyyy-MM-dd").to(end.ToString("yyyy-MM-dd")), true).OrderByDatePublished().ToList<Photo>();

                var model = new YearlyArchives
                                {
                                    Photos = photos,
                                    Year = year
                                };

                return View["yearly-archives", model];
            };

            Get[@"/(?<year>19[0-9]{2}|2[0-9]{3})/(?<month>[1-9]|1[012])"] = parameters =>
            {
                int year = Convert.ToInt32((string)parameters.year);
                int month = Convert.ToInt32((string)parameters.month);
                DateTime start = new DateTime(year, month, 1);
                DateTime end = start.AddMonths(1);

                List<Photo> photos = DB.Photos.FindAllByDatePublishedAndPublished(start.ToString("yyyy-MM-dd").to(end.ToString("yyyy-MM-dd")), true).OrderByDatePublished().ToList<Photo>();

                var model = new MonthlyArchives
                {
                    Photos = photos,
                    Month = start.ToString("MMMM yyyy")
                };

                return View["monthly-archives", model];
            };
        }
    }
}