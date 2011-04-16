using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using MyPhotoBlog.Services;

namespace MyPhotoBlog.Modules
{
    public abstract class PhotoblogModule : NancyModule
    {
        protected dynamic DB;

        public PhotoblogModule(IDBFactory dbFactory) : base()
        {
            DB = dbFactory.DB();
        }

        public PhotoblogModule(IDBFactory dbFactory, string modulePath) : base(modulePath)
        {
            DB = dbFactory.DB();
        }
    }
}