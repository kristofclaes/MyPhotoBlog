using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPhotoBlog.Modules
{
    public class RootModule : PhotoblogModule
    {
        public RootModule(): base()
        {
            Get["/"] = parameters =>
            {
                return View["photodetail"];
            };
        }
    }
}