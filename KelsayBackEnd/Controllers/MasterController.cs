using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Kelsay.Controllers
{
    public class HomeController : RenderMvcController
    {
        // Simple Redirect to the Back Office
        public ActionResult Home()
        {
            return Redirect("/umbraco");
        }
    }
}