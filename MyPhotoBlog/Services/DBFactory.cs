using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace MyPhotoBlog.Services
{
    public class DBFactory : IDBFactory
    {
        protected dynamic _db = null;

        public DBFactory()
        {

        }

        public dynamic DB()
        {
            if (_db == null)
            {
                var c = System.Web.HttpContext.Current;
                var s = ConfigurationManager.ConnectionStrings["MyPhotoBlog"];

                if (s == null || String.IsNullOrWhiteSpace(s.ConnectionString))
                {
                    _db = Simple.Data.Database.OpenFile(c.Server.MapPath("~/App_Data/MyPhotoBlog.sdf"));
                }
                else
                {
                    _db = Simple.Data.Database.OpenConnection(s.ConnectionString);
                }
            }

            return _db;
        }
    }
}