using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace MyPhotoBlog
{
    public class MainModule : NancyModule
    {
        public MainModule()
        {
            Get["/"] = parameters =>
            {
                return "<h1>Welcome to My Photoblog!</h1><p>Nothing to see here at the moment.</p>";
            };

            Get["/photo/{slug}"] = parameters =>
            {
                return String.Format("<h1>I'm sorry</h1><p>We're having some problems finding photo '{0}' for the moment.</p>", parameters.slug);
            };
        }
    }
}