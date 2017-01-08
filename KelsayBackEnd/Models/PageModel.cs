using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kelsay.Models
{
    public class PageModel
    {
        public string Name;
        public string Url;
        public string Action;
    }

    public class PageFullModel : PageModel
    {
        public string Heading;
        public string Body;
        public ComponentsModel Components;
    }

}