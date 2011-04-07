using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace MyPhotoBlog.Modules
{
    public class AuthenticationModule : PhotoblogModule
    {
        public AuthenticationModule() : base()
        {
            Get["/login"] = parameters =>
            {
                return "Display the login form";
            };

            Post["/login"] = parameters =>
            {
                // Perform validation, then redirect
                return Response.AsRedirect("/admin/photos");
            };

            Post["/logout"] = parameters =>
            {
                // Logout and redirect
                return Response.AsRedirect("/login");
            };
        }
    }
}