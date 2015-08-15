using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kelsay.Models
{

    public class PortfolioModel : ArticleModel
    {
        public List<PortfolioItemModel> Items;
    }

    public class PortfolioItemModel
    {
        public string Name;
        public string Thumbnail;
        public bool Responsive;
        public string Url;
    }

    public class PortfolioItemFullModel : PortfolioItemModel
    {
        public string Description;
        public string Slogan;
        public List<string> Images;
    }
}