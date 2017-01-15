using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Umbraco.Core.Models;
using Kelsay.Models;
using Kelsay.Code;

namespace Kelsay.Controllers.API
{
    public class SkillsetController : MasterController
    {
        public HttpResponseMessage GetAll(string parentId)
        {
            List<SkillsetModel> model = new List<SkillsetModel>();
            IPublishedContent page = GetPage(parentId);
            IEnumerable<IPublishedContent> children = page.Children.Where(x => x.DocumentTypeAlias.Equals("Skillset"));

            if (children.Any())
            {
                foreach (IPublishedContent child in children)
                {
                    SkillsetModel skillset = new SkillsetModel()
                    {
                        Title = child.Name,
                        Body = child.GetString("body"),
                        Icon = child.GetImageSrc("icon")
                    };
                    model.Add(skillset);
                }
            }

            return Json(model);
        }
    }
}
