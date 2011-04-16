using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyPhotoBlog.Services;

namespace MyPhotoBlog.Modules
{
    public class RootModule : PhotoblogModule
    {
        public RootModule(IDBFactory dbFactory) : base(dbFactory)
        {
            Get["/"] = parameters =>
            {
                // Get all photo's that are published
                var photos = DB.Photos.FindAllByPublished(true);
                List<Models.Photo> photoList = photos.ToList<Models.Photo>();

                // Order them so the newest come first
                photoList = photoList.OrderByDescending(p => p.DatePublished).ToList();

                // Get most recent photo
                var latestPhoto = photoList.FirstOrDefault();

                if (latestPhoto != null)
                {
                    var model = new Models.PhotoDetail();
                    model.Photo = latestPhoto;
                    model.NextSlug = String.Empty;

                    if (photoList.Count > 1) model.PreviousSlug = photoList[1].Slug;
                    else model.PreviousSlug = String.Empty;

                    return View["photodetail", model];
                }
                else
                {
                    return View["nophoto"];
                }
            };
        }
    }
}