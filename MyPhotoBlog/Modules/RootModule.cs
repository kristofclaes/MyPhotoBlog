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
                var photos = DB.Photos.FindAllByPublished(true).OrderByDatePublishedDescending().Take(2);
                List<Models.Photo> photoList = photos.ToList<Models.Photo>();

                if (photoList.Count > 0)
                {
                    var model = new Models.PhotoDetail();
                    model.Photo = photoList[0];
                    model.NextSlug = String.Empty;

                    if (photoList.Count > 1) model.PreviousSlug = photoList[1].Slug;
                    else model.PreviousSlug = String.Empty;

                    IEnumerable<Models.Comment> comments = DB.Comments.FindAll(DB.Comments.PhotoId == model.Photo.Id && DB.Comments.Approved == true).Cast<Models.Comment>();
                    if (comments != null) model.Comments = comments.ToList();

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