using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kelsay.Code.UmbracoViewModel
{
    public class FieldAttribute : Attribute
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}