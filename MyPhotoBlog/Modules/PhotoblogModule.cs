using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace MyPhotoBlog.Modules
{
    public abstract class PhotoblogModule : NancyModule
    {
        public PhotoblogModule() : base()
        {

        }

        public PhotoblogModule(string modulePath) : base(modulePath)
        {

        }
    }
}