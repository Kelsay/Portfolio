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

        public HttpResponseMessage GetAll(string parentId)
        {
            try
            {
                List<PortfolioModel> model = new List<PortfolioModel>();
                IPublishedContent page = Umbraco.GetRoot().Children().Where(x => x.RawUrl().Equals(parentId)).FirstOrDefault();
                if (page.Children().Any())
                {
                    foreach (IPublishedContent portfolio in page.Children())
                    {
                        IEnumerable<string> images = portfolio.GetImagesAsList("image");
                        string thumbnail = images.Any() ? images.ElementAt(0) : "";
                        model.Add(new PortfolioModel
                        {
                            Name = portfolio.Name,
                            Heading = portfolio.GetString("heading"),
                            Responsive = portfolio.GetPropertyValue<bool>("responsive"),
                            Thumbnail = thumbnail,
                            Url = portfolio.GetString("url"),
                            Slogan = portfolio.GetString("slogan")
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

        public HttpResponseMessage GetSingle(int id)
        {
            throw new NotImplementedException();
        }
    }

}