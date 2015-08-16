using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using Umbraco.Core.Models;
using Kelsay.Code;
using Kelsay.Models;

namespace Kelsay.Controllers
{
    /// <summary>
    /// Pages API
    /// Gets list of pages and single page by URL alias
    /// </summary>
    public class PagesController : MasterController
    {
        public HttpResponseMessage GetAll()
        {
            try
            {
                List<PageModel> model = new List<PageModel>();
                IPublishedContent root = Umbraco.GetRoot();
                if (root.Children.Any())
                {
                    foreach (IPublishedContent page in root.Children)
                    {
                        model.Add(new PageModel
                        {
                            Action = page.DocumentTypeAlias.ToLower(),
                            Name = page.Name,
                            Url = page.RawUrl()
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

        public HttpResponseMessage GetSingle(string id)
        {
            try
            {
                IPublishedContent page = Umbraco.GetRoot().Children.Where(x => x.RawUrl().Equals(id)).FirstOrDefault();
                PageFullModel model = new PageFullModel
                {
                    Name = page.Name,
                    Heading = page.GetString("heading"),
                    Body = page.GetString("body").ChangeUrlsToAbsolute(),
                    Url = id,
                    Action = page.DocumentTypeAlias.ToLower()
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