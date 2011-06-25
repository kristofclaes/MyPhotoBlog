using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.ModelBinding;
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

                    IEnumerable<Models.Comment> comments = DB.Comments.FindAll(DB.Comments.PhotoId == model.Photo.Id && DB.Comments.Approved == true).Cast<Models.Comment>();
                    if (comments != null) model.Comments = comments.ToList();

                    bool commenterror = false;
                    if (Boolean.TryParse(Convert.ToString(Session["commenterror"]), out commenterror))
                    {
                        model.ErrorMessage = "Please fill out all required fields and make sure the email address you enter is valid.";
                        Session.Delete("commenterror");
                    }

                    return View["photodetail", model];
                }
            };

            Post["/{slug}/addcomment"] = parameters =>
            {
                string photoSlug = (string)parameters.slug;

                int? photoId = DB.Photos.Query().Select(DB.Photos.Id).Where(DB.Photos.Slug == photoSlug).ToScalarOrDefault<int?>();

                if (photoId.HasValue)
                {
                    Models.Comment comment = this.Bind<Models.Comment>("Id", "PhotoId", "Approved");
                    comment.PhotoId = photoId.Value;
                    comment.Approved = true;

                    if (comment.IsValid())
                    {
                        DB.Comments.Insert(comment);
                    }
                    else
                    {
                        Session["commenterror"] = true;
                    }

                    return Response.AsRedirect(String.Format("/photo/{0}#comments", photoSlug));
                }
                else
                {
                    // No photo found with this slug, we'll just redirect to the homepage
                    return Response.AsRedirect("/");
                }                
            };
        }
    }
}