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

/*
namespace Kelsay.Models
{
    public class ComponentsModel
    {
        public List<Container> Containers { get; set; }
        public List<string> log = new List<string>();

        public ComponentsModel(string json)
        {
            try
            {
                var unescaped = Regex.Unescape(json);
                JObject model = JsonConvert.DeserializeObject<JObject>(json);

                var sections = GetArray(model, "sections");
                foreach (var section in sections.Cast<JObject>())
                {
                    Container container = new Container();

                    //log.Add("New section");

                    var rows = GetArray(section, "rows");
                    foreach (var row in rows.Cast<JObject>())
                    {
                        //log.Add("New row");

                        var areas = GetArray(row, "areas");
                        foreach (var area in areas.Cast<JObject>())
                        {
                            //log.Add("New area");

                            Widget widget = new Widget();

                            var controls = GetArray(area, "controls");
                            foreach (var control in controls.Cast<JObject>())
                            {
                                var value = GetArray(control, "value");

                                foreach (var field in value)
                                {
                                    log.Add(field.ToString());
                                }


                                var editor = control.Value<JObject>("editor");
                                if (editor != null)
                                {
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                LogHelper.Error<ComponentsModel>("Can't parse the Components", e);
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

        private JToken GetObject(JObject obj, string propertyName)
        {
            JToken token;
            if (obj.TryGetValue(propertyName, out token))
            {
                return token ?? new JObject();
            }

            return new JObject();
        }

    }

    public class Container : List<Widget>
    {
        public string Grid;
        public string Type;
        public List<Widget> items { get; set; }

        public Container()
        {
            items = new List<Widget>();
        }
    }

    public class Widget : Dictionary<String, String>
    {
        public string Type;
    }

    public class Value
    {
        public string value { get; set; }
        public string dateTypeGuid { get; set; }
        public string editorAlias { get; set; }
    }
} */
