using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using MyPhotoBlog.Services;

namespace MyPhotoBlog.Modules
{
    public class PhotoModule : PhotoblogModule
    {
        public PhotoModule(IDBFactory dbFactory) : base(dbFactory, "/photo")
        {
            Get["/{slug}"] = parameters =>
            {
                return String.Format("Photo '{0}'", parameters.slug);
            };

            Post["/{slug}/addcomment"] = parameters =>
            {
                string photoSlug = Convert.ToString(parameters.slug);
                return Response.AsRedirect("/photo/" + photoSlug);
            };
        }
    }
}