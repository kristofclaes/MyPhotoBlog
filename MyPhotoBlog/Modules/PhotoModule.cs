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
                string slug = (string)parameters.slug;
                Models.Photo photo = DB.Photos.FindBySlug(slug);

                if (photo == null)
                {
                    // No photo found with this slug, we'll just redirect to the homepage
                    return Response.AsRedirect("/");
                }
                else
                {
                    var model = new Models.PhotoDetail();
                    model.Photo = photo;

                    model.PreviousSlug = DB.Photos.Query().Select(DB.Photos.Slug).Where(DB.Photos.Published == true && DB.Photos.DatePublished < photo.DatePublished.Value).OrderByDatePublishedDescending().Take(1).ToScalarOrDefault<string>();
                    model.NextSlug = DB.Photos.Query().Select(DB.Photos.Slug).Where(DB.Photos.Published == true && DB.Photos.DatePublished > photo.DatePublished.Value).OrderByDatePublished().Take(1).ToScalarOrDefault<string>();

                    return View["photodetail", model];
                }
            };

            Post["/{slug}/addcomment"] = parameters =>
            {
                string photoSlug = Convert.ToString(parameters.slug);
                return Response.AsRedirect("/photo/" + photoSlug);
            };
        }
    }
}