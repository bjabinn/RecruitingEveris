using RecruitingWeb.Helpers;
using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RecruitingWeb.Components.DataTable.Models
{
    
    public class Column<TModel, TValue> : BaseColumn<TModel>
    {
        private readonly Func<TValue, string> _format;
        private readonly Func<TModel, TValue> _value;

        public Column(Func<TModel, TValue> expression, Func<TValue, string> formatExpression)
        {
            _value = expression;
            _format = formatExpression;
        }

        public override MvcHtmlString Value(TModel modelRow)
        {
            var value = _value(modelRow);
            if (value == null)
            {
                return null;
            }

            var formatedValue = _format != null ? _format(value) : value.ToString();

            return formatedValue.HtmlEncode();
        }

        public override MvcHtmlString ResolvedAttributes(TModel modelRow)
        {
            var attributesString = new StringBuilder();
            foreach (var attribute in Attributes)
            {
                var value = HttpUtility.HtmlEncode(attribute.Value(modelRow));
                if (!string.IsNullOrWhiteSpace(value))
                {
                    attributesString.AppendFormat(@"{0}=""{1}""", attribute.Key, value);
                }
            }
            return new MvcHtmlString(attributesString.ToString());
        }
    }
}