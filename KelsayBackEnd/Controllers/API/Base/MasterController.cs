using Kelsay.Code;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.WebApi;
using System.Linq;

namespace Kelsay.Controllers
{

    /// <summary>
    /// Base class for Api Controllers, providing output defaults
    /// </summary>

    public abstract class MasterController : UmbracoApiController
    {
        // Default JSON settings
        public JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            // Convert property keys to camelCase
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        #region Helpers
        /// <summary>
        /// Get the (top-level) page based on the alias
        /// </summary>
        /// <param name="alias">String alias of the page</param>
        /// <returns>Published Umbraco page</returns>
        public IPublishedContent GetPage(string alias)
        {
            try
            {
                return Umbraco.GetRoot().Children().Where(x => x.RawUrl().Equals(alias)).FirstOrDefault();
            }
            catch (Exception innerException)
            {
                throw new Exception("Error: could not find Umbraco page with alias " + alias, innerException);
            }

        }

        /// <summary>
        /// Return response Json
        /// Keys are converted to Javascript standard camelCase
        /// </summary>
        /// <param name="model">Object to serialize</param>
        /// <returns></returns>
        public HttpResponseMessage Json(Object model)
        {
            try
            {
                string result = JsonConvert.SerializeObject(model, JsonSettings);
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(result, Encoding.UTF8, "application/json")
                };
                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
        #endregion

    }
}