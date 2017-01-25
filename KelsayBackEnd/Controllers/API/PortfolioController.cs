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
            int start = 0;
            int limit = 12;
            string startPosition = Request.GetQueryNameValuePairs()
                .SingleOrDefault(x => x.Key == "start")
                .Value;
            Int32.TryParse(startPosition, out start);

            try
            {
                PortfolioListModel model = new PortfolioListModel();
                IPublishedContent page = GetPage(parentId);
                if (page.Children().Any())
                {
                    IEnumerable<IPublishedContent> items = page.Children()
                        .Where(x => x.DocumentTypeAlias.Equals("Site"))
                        .Skip(start)
                        .Take(limit);

                    foreach (IPublishedContent portfolio in items)
                    {
                        // Prepare data
                        IEnumerable<string> images = portfolio.GetImagesAsList("image", 400, 300);
                        string thumbnail = images.Any() ? images.ElementAt(0) : "";
                        Uri alias = new Uri(portfolio.UrlAbsolute());

                        // Add current item to the model
                        model.Items.Add(new PortfolioModel
                        {
                            Name = portfolio.Name,
                            Heading = portfolio.GetString("heading"),
                            Responsive = portfolio.GetPropertyValue<bool>("responsive"),
                            Thumbnail = thumbnail,
                            SiteUrl = portfolio.GetString("url"),
                            Slogan = portfolio.GetString("slogan"),
                            Url = alias.Segments.Last().TrimEnd('/')
                        });

                        // Mark the last page
                        if (portfolio.IsLast())
                        {
                            model.IsLast = true;
                        }

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
                PortfolioFullModel model = new PortfolioFullModel
                {
                    Images = page.GetImagesAsList("image", 400, 300),
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