using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Umbraco.Web.WebApi;

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