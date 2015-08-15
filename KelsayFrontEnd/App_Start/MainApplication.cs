using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Kelsay.App_Start
{
    public class MainApplication : HttpApplication
    {

        private const string ROOT_DOCUMENT = "/index.html";

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            string url = Request.Url.LocalPath;
            if (!System.IO.File.Exists(Context.Server.MapPath(url)))
                Context.RewritePath(ROOT_DOCUMENT);
        }

    }

}