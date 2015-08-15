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

namespace Kelsay.Controllers.API
{
    /// <summary>
    /// Gets all menu items with appropriate data
    /// </summary>
    public class MenuController : MasterController
    {

        public HttpResponseMessage GetAll()
        {
            List<MenuModel> model = new List<MenuModel>();
            IEnumerable<IPublishedContent> pages = Umbraco.GetRoot().Children();
            if (pages.Any())
            {
                foreach (IPublishedContent page in pages)
                {
                    model.Add(new MenuModel()
                    {
                         Action = page.DocumentTypeAlias.ToLower(),
                         Id = page.Id,
                         Name = page.Name
                    });
                }
            }
            return Json(model);
        }
    }
}