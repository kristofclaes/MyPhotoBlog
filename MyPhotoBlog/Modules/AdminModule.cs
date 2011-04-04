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
            Get[""] = parameters =>
            {
                return "Display the login form.";
            };

            Post["/login"] = parameters =>
            {
                // Perform validation, then redirect
                return Response.AsRedirect("/admin/photos");
            };

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