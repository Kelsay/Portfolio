using System.Collections.Generic;

namespace Kelsay.Models
{

    public class PortfolioModel
    {
        public string Name;
        public string Heading;
        public string Slogan;
        public string Thumbnail;
        public bool Responsive;
        public string SiteUrl;
        public string Url;
    }

    public class PortfolioFullModel : PortfolioModel
    {
        public string Description;
        public IEnumerable<string> Images;
    }
}