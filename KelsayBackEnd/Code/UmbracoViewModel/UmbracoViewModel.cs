using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

namespace Kelsay.Code
{
    public class UmbracoViewModel<T>
    {
        public UmbracoViewModel(T model, IPublishedContent page)
        {

        }

        private void MapFields()
        {

        }
    }
}