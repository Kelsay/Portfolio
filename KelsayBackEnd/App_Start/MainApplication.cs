using System;
using System.Linq;
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

            // Routes
            RouteTable.Routes.Ignore("{resource}.axd/{*pathInfo}"); 
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }


        // Ensure OPTIONS for all the requests
        
        protected void Application_BeginRequest()
        {
            if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
            {
                Response.Flush();
            }
        }

    }
}