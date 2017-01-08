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

    public class MasterController : UmbracoApiController
    {

        // Default JSON settings
        
        public JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            // Convert property keys to camelCase
            ContractResolver = new CamelCasePropertyNamesContractResolver() 
        };

        // Get the page based on the alias
        public IPublishedContent GetPage(string alias)
        {
            return Umbraco.GetRoot().Children().Where(x => x.RawUrl().Equals(alias)).FirstOrDefault();
        }

        // Return response Json
        // Keys are converted to Javascript standard camelCase
        public HttpResponseMessage Json(Object model)
        {
            string result = JsonConvert.SerializeObject(model, JsonSettings);
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(result, Encoding.UTF8, "application/json")
            };
            return response;
        }

    }
}