using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace MyPhotoBlog.Modules
{
    public class AdminModule : PhotoblogModule
    {
        public AdminModule() : base("/admin")
        {
            Get["/photos"] = parameters =>
            {
                return "A list of all the photo's.";
            };

            Get["/photos/add"] = parameters =>
            {
                return "Display the form to add a photo.";
            };

            Post["/photos/add"] = parameters =>
            {
                // Add the photo, then redirect
                string slug = "newPhoto";
                return Response.AsRedirect("/admin/photos/edit/" + slug);
            };

            Get["/photos/edit/{slug}"] = parameters =>
            {
                return String.Format("Display the form to edit a photo called '{0}'.",
                    parameters.slug);
            };

            Post["/photos/edit/{slug}"] = parameters =>
            {
                // Edit the photo, then redirect
                string slug = Convert.ToString(parameters.slug);
                return Response.AsRedirect("/admin/photos/edit/" + slug);
            };

            Get["/photos/delete/{slug}"] = parameters =>
            {
                return String.Format("Are you sure you want to delete the photo called '{0}'?",
                    parameters.slug);
            };

            Post["/photos/delete/{slug}"] = parameters =>
            {
                // Delete the photo, then redirect
                return Response.AsRedirect("/admin/photos");
            };

            Get["/comments"] = parameters =>
            {
                return "A list of all the comments.";
            };

            Post["/comments/delete/{id}"] = parameters =>
            {
                // Delete the comment, then redirect
                return Response.AsRedirect("/admin/comments");
            };
        }
    }
}