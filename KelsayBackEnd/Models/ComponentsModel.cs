using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Logging;
using System.Text.RegularExpressions;



namespace Kelsay.Models
{
    /// <summary>
    /// Parse the json and map the values to the model
    /// </summary>
    public class ComponentsModel : List<RowModel>
    {
        /// <summary>
        /// Contructor taking the default json string from Umbraco and mapping it to the values
        /// </summary>
        /// <param name="json">Standard JSON output from umbraco grid layout</param>
        public ComponentsModel(string json)
        {

            // Iterate over the object
            try
            {
                JObject layout = JsonConvert.DeserializeObject<JObject>(json);

                var sections = GetArray(layout, "sections").Cast<JObject>();
                foreach (var section in sections)
                {
                    var rows = GetArray(section, "rows").Cast<JObject>();
                    foreach (var row in rows)
                    {
                        RowModel rowModel = new RowModel();
                        var areas = GetArray(row, "areas").Cast<JObject>();
                        foreach (var area in areas)
                        {
                            Widget widget = new Widget();

                            var controls = GetArray(area, "controls").Cast<JObject>();
                            foreach (var control in controls)
                            {
                                JToken value, editor;
                                control.TryGetValue("value", out value);
                                control.TryGetValue("editor", out editor);

                                foreach (JToken token in value)
                                {
                                    foreach (JProperty field in token.Children())
                                    {
                                        FieldValue fieldValue = new FieldValue(field);
                                        widget.Add(field.Name, fieldValue.ToString());
                                    }
                                }

                            }

                            rowModel.Add(widget);
                        }
                        this.Add(rowModel);
                    }
                }

            }
            catch
            {

            }

        }

        private JArray GetArray(JObject obj, string propertyName)
        {
            JToken token;
            if (obj.TryGetValue(propertyName, out token))
            {
                var asArray = token as JArray;
                return asArray ?? new JArray();
            }
            return new JArray();
        }
    }

    public class RowModel : List<Widget>
    {

    }

    public class Widget : Dictionary<String, String>
    {
        public int width;
    }

    public class FieldValue
    {
        public string Value { get; set; }
        public string dateTypeGuid { get; set; }
        public string editorAlias { get; set; }

        public FieldValue(JProperty field)
        {
            JToken value;
            JObject v = (JObject)field.Value;
            if (v.TryGetValue("value", out value))
            {
                Value = value.ToString();
            }
        }

        override public string ToString()
        {
            return Value;
        }
    }

}