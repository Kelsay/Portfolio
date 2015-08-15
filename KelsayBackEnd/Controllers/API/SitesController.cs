using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;
using Kelsay.Models;
using Kelsay.Code;


namespace Kelsay.Controllers
{
    public class SitesController : MasterController
    {

        public HttpResponseMessage GetAll()
        {
            List<PortfolioModel> model = new List<PortfolioModel>();
            IEnumerable<IPublishedContent> sites = Umbraco.GetAllNodes("Site");
            if (sites.Any())
            {
                foreach (IPublishedContent site in sites)
                {
                    // Get first image as thumbnail
                    IEnumerable<string> images = site.GetImagesAsList("image");
                    string thumbnail = images.Any() ? images.ElementAt(0) : "";

                    // Get page data to model
                    model.Add(new PortfolioModel()
                    {
                        Name = site.Name,
                        Thumbnail = thumbnail,
                        Responsive = site.GetPropertyValue<bool>("responsive"),
                        Url = site.GetString("url")
                    });
                }
            }
            return Json(model);
        }

    }
}