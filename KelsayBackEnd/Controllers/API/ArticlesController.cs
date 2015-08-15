using Kelsay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using Umbraco.Core.Models;
using Kelsay.Code;

namespace Kelsay.Controllers.API
{
    public class ArticlesController : MasterController
    {

        public HttpResponseMessage GetAll()
        {
            return Json("");
        }

        public HttpResponseMessage GetById(int id)
        {
            try
            {
                IPublishedContent page = Umbraco.TypedContent(id);
                ArticleModel model = new ArticleModel()
                {
                    Id = page.Id,
                    Alias = page.GetString("alias"),
                    Heading = page.GetString("heading"),
                    Body = page.GetString("body").ChangeUrlsToAbsolute()
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