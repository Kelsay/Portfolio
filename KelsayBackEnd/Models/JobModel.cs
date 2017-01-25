using Kelsay.Code.UmbracoViewModel;

namespace Kelsay.Models
{
    public class JobModel
    {
        public string Name;
        public string Description;
        public string Location;
        [Field(Name = "Icon", Type = "Image")]
        public string Icon;
        public string DateStart;
        public string DateEnd;
    }
}