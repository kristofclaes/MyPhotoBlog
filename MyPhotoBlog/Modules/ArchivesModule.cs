using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPhotoBlog.Modules
{
    public class ArchivesModule : PhotoblogModule
    {
        public ArchivesModule() : base("/archives")
        {
            Get[""] = parameters =>
            {
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