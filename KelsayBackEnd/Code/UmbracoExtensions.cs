using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Kelsay.Code
{
    public static class UmbracoExtensions
    {

        // Exposing Umbraco Helper
       private static UmbracoHelper Umbraco = new UmbracoHelper(UmbracoContext.Current);

        /// <summary>
        /// Returns content of given field as a string.
        /// </summary>
        /// <param name="field">Alias of the text field</param>
        /// <returns>Field content as string</returns>
        public static string GetString(this IPublishedContent page, string field)
        {
            return page.GetPropertyValue<string>(field, string.Empty);
        }

        /// <summary>
        /// Returns content of given field as a HtmlString.
        /// </summary>
        /// <param name="field">Alias of the text field</param>
        /// <returns>Field content as HtmlString</returns>
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
            return GetRoot();
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

        /// <summary>
        /// Get list of image URLs from page with multiple image field
        /// Specify width and height if required
        /// </summary>
        /// <param name="page">Umbraco page</param>
        /// <param name="fieldName">Name of the multiple image field</param>
        /// <param name="width">Optional width</param>
        /// <param name="height">Optional height</param>
        /// <returns></returns>
        public static List<string> GetImagesAsList(this IPublishedContent page, string fieldName, int? width = null, int? height = null)
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
                        urls.Add(GetImageSrc(id, width, height));
                    }
                }
            }
            return urls;
        }

        /// <summary>
        /// Get Image source as string based on the field name and optional width / height
        /// </summary>
        /// <param name="page">IPublishedContent Umbraco document</param>
        /// <param name="fieldName">string field id</param>
        /// <param name="width">Optional width</param>
        /// <param name="height">Optional height</param>
        /// <returns></returns>
        public static string GetImageSrc(this IPublishedContent page, string fieldName, int? width = null, int? height = null)
        {
            string id = page.GetString(fieldName);
            if (!string.IsNullOrEmpty(fieldName) && !string.IsNullOrEmpty(id))
            {
                return GetImageSrc(id, width, height);
            }
            return "";
        }

        /// <summary>
        /// Get the image url from Umbraco Media object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static string GetImageSrc(string id, int? width = null, int? height = null)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                IPublishedContent media = Umbraco.TypedMedia(int.Parse(id));
                if (media != null)
                {
                    string host = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host;
                    if (width != null || height != null)
                    {
                        return host + media.GetCropUrl(width, height);
                    }
                    else
                    {
                        return host + media.Url;
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// Convert the relative URL to absolute
        /// </summary>
        /// <param name="media"></param>
        /// <returns></returns>
        public static string GetAbsoluteUrl(this IPublishedContent media)
        {
            string host = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host;
            return host + media.Url;
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