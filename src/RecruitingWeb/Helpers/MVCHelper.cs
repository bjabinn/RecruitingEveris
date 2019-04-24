using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace RecruitingWeb.Helpers
{
    public static class MvcHelper
    {
        private static readonly string ScriptBlockBufferKey = "RecruitingWeb.Presentation.ScriptBlockBuffer";

        public static MvcHtmlString HtmlEncode(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }
            var encodeText = HttpUtility.HtmlEncode(text);
            encodeText = encodeText.Replace("\n", "<br />");
            return new MvcHtmlString(encodeText);
        }

        public static string GetSelectedItem(string value, IEnumerable<SelectListItem> optionList)
        {
            var selectedItem = optionList.FirstOrDefault(x => x.Value == value);
            return selectedItem == null ? null : selectedItem.Text;
        }

        public static string GetSelectedItem(int? value, IEnumerable<SelectListItem> optionList)
        {
            string stringValue = value.HasValue ? value.ToString() : null;
            return GetSelectedItem(stringValue, optionList);
        }

        public static string GetSelectedItem(string value, IEnumerable<object> optionList, string valuePropertyName, string textPropertyName)
        {
            var selectedItem = optionList.FirstOrDefault(x => GetReflectionValue(x, valuePropertyName) == value);
            return selectedItem == null ? null : GetReflectionValue(selectedItem, textPropertyName);
        }

        public static string GetSelectedItem(int? value, IEnumerable<object> optionList, string valuePropertyName, string textPropertyName)
        {
            string stringValue = value.HasValue ? value.ToString() : null;
            return GetSelectedItem(stringValue, optionList, valuePropertyName, textPropertyName);
        }

        public static string GetReflectionValue(object item, string propertyName)
        {
            if ((item == null) || (propertyName == null))
            {
                return null;
            }

            var property = item.GetType().GetProperty(propertyName);
            if (property == null)
            {
                return null;
            }

            var value = property.GetValue(item);
            return value == null ? null : value.ToString();
        }

        public static MvcHtmlString GetReflectionAttributes(Dictionary<string, string> attributeRelations, object item)
        {
            if ((attributeRelations == null) || (item == null) || !attributeRelations.Any())
            {
                return null;
            }

            var textHtml = string.Empty;
            foreach (var relation in attributeRelations)
            {
                if (!string.IsNullOrWhiteSpace(relation.Key) && !string.IsNullOrWhiteSpace(relation.Value))
                {
                    var data = string.Format("data-{0}", relation.Key);
                    var value = GetReflectionValue(item, relation.Value);
                    if (value != null)
                    {
                        textHtml = string.Format("{0} {1}=\"{2}\"", textHtml, data, value);
                    }
                }
            }
            return new MvcHtmlString(textHtml);
        }

        public static MvcHtmlString ScriptBlock(this HtmlHelper htmlHelper, Func<dynamic, HelperResult> template)
        {
            var context = htmlHelper.ViewContext.HttpContext;

            if (!context.Request.IsAjaxRequest())
            {
                var scriptBuilder = context.Items[ScriptBlockBufferKey] as StringBuilder ?? new StringBuilder();

                scriptBuilder.Append(template(null).ToHtmlString());
                context.Items[ScriptBlockBufferKey] = scriptBuilder;

                return new MvcHtmlString(string.Empty);
            }

            return new MvcHtmlString(template(null).ToHtmlString());
        }

        public static MvcHtmlString WriteScriptBlocks(this HtmlHelper htmlHelper)
        {
            var scriptBuilder = htmlHelper.ViewContext.HttpContext.Items[ScriptBlockBufferKey] as StringBuilder ?? new StringBuilder();

            return new MvcHtmlString(scriptBuilder.ToString());
        }

    }
}