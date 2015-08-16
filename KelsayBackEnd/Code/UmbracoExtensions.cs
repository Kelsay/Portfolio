using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Kelsay.Code
{
    public static class UmbracoExtensions
    {

        // Exposing Umbraco Helper
        static UmbracoHelper Umbraco = new UmbracoHelper(UmbracoContext.Current);

        /// <summary>
        /// Returns content of given field as a string.
        /// </summary>
        /// <param name="field">Alias of the text field</param>
        /// <returns></returns>
        public static string GetString(this IPublishedContent page, string field)
        {
            return page.GetPropertyValue<string>(field, string.Empty);
        }

        /// <summary>
        /// Returns content of given field as a HtmlString.
        /// </summary>
        /// <param name="field">Alias of the text field</param>
        /// <returns></returns>
        public static HtmlString GetHtmlString(this IPublishedContent page, string field)
        {
            return page.GetPropertyValue<HtmlString>(field, new HtmlString(""));
        }

        public static IPublishedContent GetRoot()
        {
            return Umbraco.TypedContentAtRoot().Where(x => x.DocumentTypeAlias.Equals("Master")).FirstOrDefault();
        }

        public static IPublishedContent GetRoot(this UmbracoHelper Umbraco)
        {
            return Umbraco.TypedContentAtRoot().Where(x => x.DocumentTypeAlias.Equals("Master")).FirstOrDefault();
        }

        /// <summary>
        /// Returns all Documents of given type identified by alias
        /// </summary>
        /// <param name="type">Document Type Alias</param>
        /// <returns></returns>
        public static IEnumerable<IPublishedContent> GetAllNodes(this UmbracoHelper umbraco, string type)
        {
            IPublishedContent root = GetRoot();
            IEnumerable<IPublishedContent> pages = root.Descendants(type);
            return pages;
        }



        public static IEnumerable<string> GetImagesAsList(this IPublishedContent page, string fieldName)
        {
            string fieldValue = page.GetString(fieldName);
            List<string> urls = new List<string>();
            if (!string.IsNullOrWhiteSpace(fieldValue))
            {
                List<string> ids = fieldValue.Split(',').ToList<string>();
                if (ids.Any())
                {
                    foreach (string id in ids)
                    {
                        urls.Add(GetImageSrc(id));
                    }
                }
            }
            return urls;
        }



        // Get Image Source
        public static string GetImageSrc(this IPublishedContent page, string fieldName)
        {
            string id = page.GetString(fieldName);
            if (!string.IsNullOrEmpty(fieldName) && !string.IsNullOrEmpty(id))
            {
                return GetImageSrc(id);
            }
            return "";
        }



        public static string GetImageSrc(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                IPublishedContent media = Umbraco.TypedMedia(int.Parse(id));
                if (media != null)
                {
                    string host = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host;
                    return host + media.Url;
                }
            }
            return "";
        }



        /// <summary>
        /// Gets the absolute URL to the cropped image
        /// </summary>
        /// <param name="fieldName">Alias of the image field</param>
        /// <param name="cropName">Alias of the crop preset</param>
        /// <returns> Absolute path to the cropped image</returns>
        public static string GetThumbnail(this IPublishedContent page, string fieldName, string cropName)
        {
            string host = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host;
            return host + page.GetCropUrl(fieldName, cropName);
        }

        /// <summary>
        /// Returns url without leading and trailing slashes
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static string RawUrl(this IPublishedContent page)
        {
            return page.Url.TrimStart('/').TrimEnd('/');
        }


        /*
        public static T MapTo<T>(this IPublishedContent page) where T : new()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo property in properties)
            {
            }
            return new T();
        }
         * */

    }
}