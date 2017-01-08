using Kelsay.Code;
using Kelsay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Umbraco.Core.Models;

namespace Kelsay.Controllers.API
{
    public class JobsController : MasterController
    {

        public HttpResponseMessage GetAll(string parentId)
        {
            IPublishedContent page = GetPage(parentId);
            IEnumerable<IPublishedContent> children = page.Children.Where(x => x.DocumentTypeAlias.Equals("Job"));
            List<JobModel> model = new List<JobModel>();

            if (children.Any())
            {
                foreach(IPublishedContent child in children)
                {
                    JobModel job = new JobModel()
                    {
                        Name = child.Name,
                        Description = child.GetString("description"),
                        DateStart = child.GetString("dateStart"),
                        DateEnd = child.GetString("dateEnd"),
                        Icon = child.GetImageSrc("icon"),
                        Location = child.GetString("location")
                    };
                    model.Add(job);
                }
            }

            return Json(model);
        }

    }
}