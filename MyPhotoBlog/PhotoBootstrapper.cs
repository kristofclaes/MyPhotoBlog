using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.Cryptography;

namespace MyPhotoBlog
{
    public class PhotoBootstrapper : DefaultNancyBootstrapper
    {
        protected override void InitialiseInternal(TinyIoC.TinyIoCContainer container)
        {
            base.InitialiseInternal(container);
            Nancy.Session.CookieBasedSessions.Enable(this, CryptographyConfiguration.Default);
        }
    }
}