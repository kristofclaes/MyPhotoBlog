using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyPhotoBlog.Services;

namespace MyPhotoBlog.Modules
{
    public class ArchivesModule : PhotoblogModule
    {
        public ArchivesModule(IDBFactory dbFactory) : base(dbFactory, "/archives")
        {
            Get[""] = parameters =>
            {
                var allDates = DB.Photos.Query().Select(DB.Photos.DatePublished).Where(DB.Photos.Published == true).OrderByDatePublishedDescending().ToScalarList<DateTime>();

                return "All photo's of all years and months.";
            };

            Get[@"/(?<year>19[0-9]{2}|2[0-9]{3})"] = parameters =>
            {
                return String.Format("All photo's of the year {0}",
                    parameters.year);
            };

            Get[@"/(?<year>19[0-9]{2}|2[0-9]{3})/(?<month>0[1-9]|1[012])"] = parameters =>
            {
                return String.Format("All photo's of month {0} of the year {1}",
                    parameters.month,
                    parameters.year);
            };
        }
    }
}