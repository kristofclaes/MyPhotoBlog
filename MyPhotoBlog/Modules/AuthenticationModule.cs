using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using MyPhotoBlog.Services;

namespace MyPhotoBlog.Modules
{
    public class AuthenticationModule : PhotoblogModule
    {
        public AuthenticationModule(IDBFactory dbFactory) : base(dbFactory)
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