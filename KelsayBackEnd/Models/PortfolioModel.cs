using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kelsay.Models
{

    public class PortfolioModel
    {
        public string Name;
        public string Heading;
        public string Slogan;
        public string Thumbnail;
        public bool Responsive;
        public string Url;
    }

    public class PortfolioFullModel : PortfolioModel
    {
        public string Description;
        public List<string> Images;
    }
}