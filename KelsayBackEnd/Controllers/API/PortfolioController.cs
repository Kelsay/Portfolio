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
using System.Web.Http;


namespace Kelsay.Controllers
{

    public class PortfolioController : MasterController
    { 

        public HttpResponseMessage GetAll(string parentId)
        {
            try
            {
                List<PortfolioModel> model = new List<PortfolioModel>();
                IPublishedContent page = GetPage(parentId);
                if (page.Children().Any())
                {
                    foreach (IPublishedContent portfolio in page.Children())
                    {
                        IEnumerable<string> images = portfolio.GetImagesAsList("image");
                        string thumbnail = images.Any() ? images.ElementAt(0) : "";
                        Uri alias = new Uri(portfolio.UrlAbsolute());
                        model.Add(new PortfolioModel
                        {
                            Name = portfolio.Name,
                            Heading = portfolio.GetString("heading"),
                            Responsive = portfolio.GetPropertyValue<bool>("responsive"),
                            Thumbnail = thumbnail,
                            SiteUrl = portfolio.GetString("url"),
                            Slogan = portfolio.GetString("slogan"),
                            Url = alias.Segments.Last().TrimEnd('/')
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

        [Route("page/{parentId}/portfolio/{id}")]
        public HttpResponseMessage GetSingle(string parentId, string id)
        {
            try
            {
                string fullUrl = "/" + parentId + "/" + id + "/";
                IPublishedContent parent = Umbraco.GetRoot().Children().Where(x => x.RawUrl().Equals(parentId)).FirstOrDefault();
                IPublishedContent page = parent.Children().Where(x => x.Url.Equals(fullUrl)).FirstOrDefault();
                PortfolioFullModel model = new PortfolioFullModel { 
                    Images = page.GetImagesAsList("image"),
                    Description = page.GetString("description"),
                    Name = page.Name,
                    SiteUrl = page.GetString("url"),
                    Heading = page.GetString("heading")
                };
                return Json(model);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

    }

}