using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kelsay.Code
{
    public static class StringExtensions
    {

        public static string ChangeUrlsToAbsolute(this string text)
        {
            string host = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + "/";
            string replaced = text.Replace("src=\"/", "src=\"" + host)
                                  .Replace("href=\"/", "href=\"" + host);
            return replaced;
        }

    }
}