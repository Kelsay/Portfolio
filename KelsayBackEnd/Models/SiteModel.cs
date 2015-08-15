using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kelsay.Models
{
    public class SiteModel
    {
        public string Name;
        public string Thumbnail;
        public bool Responsive;
        public string Url;
    }

    public class SiteFullModel : SiteModel
    {
        public string Description;
        public string Slogan;
        public List<string> Images;
    }
}