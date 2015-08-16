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
using System.Net;


namespace Kelsay.Controllers
{

    public class PortfolioController : MasterController
    {

        public HttpResponseMessage GetAll()
        {
            return Json("");
        }

        public HttpResponseMessage GetSingle(int id)
        {
            try
            {
                IPublishedContent page = Umbraco.TypedContent(id);
                PortfolioModel model = new PortfolioModel()
                {
                    Id = page.Id,
                    Alias = page.GetString("alias"),
                    Heading = page.GetString("heading"),
                    Body = page.GetString("body"),
                    Items = new List<PortfolioItemModel>()
                };

                // Portfolio items 
                IEnumerable<IPublishedContent> items = page.Descendants("Site");
                if (items.Any())
                {
                    foreach (IPublishedContent item in items)
                    {
                        // Get first image as thumbnail
                        IEnumerable<string> images = item.GetImagesAsList("image");
                        string thumbnail = images.Any() ? images.ElementAt(0) : "";
                        model.Items.Add(new PortfolioItemModel()
                        {
                            Name = item.Name,
                            Thumbnail = thumbnail,
                            Responsive = item.GetPropertyValue<bool>("responsive"),
                            Url = item.GetString("url")
                        });
                    }
                }

                return Json(model);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }

}