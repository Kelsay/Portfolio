﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Http.Cors;

namespace Kelsay.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Enable CORS
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Route config
            // List all - eg. api.com/sites
            config.Routes.MapHttpRoute(
                name: "GetAll",
                routeTemplate: "{controller}",
                defaults: new { action = "GetAll" }
            );
            
            // List specific eg. sites/1234
            config.Routes.MapHttpRoute(
                name: "GetSingle",
                routeTemplate: "{controller}/{id}",
                defaults: new { action = "GetSingle" }
            );

            // Child controller - list
            config.Routes.MapHttpRoute(
                name: "GetAllChildren",
                routeTemplate: "{parentController}/{parentId}/{controller}",
                defaults: new {  action = "GetAll" }
            );

            // Child controller - single
             config.Routes.MapHttpRoute(
                name: "GetSingleChild",
                routeTemplate: "{parentController}/{parentId}/{controller}/{id}",
                defaults: new { action = "GetSingle" }
            );


        }
    }
}