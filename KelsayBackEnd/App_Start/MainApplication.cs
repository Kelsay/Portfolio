using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Umbraco.Web;

namespace Kelsay.App_Start
{
    public class MainApplication : UmbracoApplication
    {

        new void Application_Start(object sender, EventArgs e)
        {
            base.Application_Start(sender, e);
            RouteTable.Routes.Ignore("{resource}.axd/{*pathInfo}"); // Ignore axd resource routes
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_BeginRequest()
        {
            if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
            {
                Response.Flush();
            }
        }

    }
}