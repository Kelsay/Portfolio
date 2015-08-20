using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kelsay.Models
{
    public class ImageModel
    {
        public string Title;
        public List<ImageSourceModel> Images;
    }

    public class ImageSourceModel
    {
        public string Breakpoint;
        public string Source;
    }
}