using System;
using System.Globalization;
using System.Text;

namespace RecruitingWeb.Helpers
{
    public static class FormatHelper
    {
        public static string Format(DateTime? value, string formatString)
        {
            return value != null ? value.Value.ToString(formatString) : null;
        }

        public static string Format(decimal? value, string formatString)
        {
            return value != null ? value.Value.ToString(formatString) : null;
        }

        public static string Format(bool? value, Func<bool, string> formatExpression)
        {
            return value != null ? formatExpression(value.Value) : null;
        }

        public static string GetHtmlMoneda(string moneda)
        {
            var htmlMoneda = "<i class=\"glyphicon glyphicon-euro \"></i>";
            if (moneda == "EUR")
            {
                htmlMoneda = "<i class=\"glyphicon glyphicon-euro \"></i>";
            }
            if (moneda == "ARS")
            {
                htmlMoneda = "<i class=\"glyphicon\">ARS</i>";
            }
            if (moneda == "CLP")
            {
                htmlMoneda = "<i class=\"glyphicon\">CLP</i>";
            }
            if (moneda == "BRL")
            {
                htmlMoneda = "<i class=\"glyphicon\">BRL</i>";
            }
            if (moneda == "PEN")
            {
                htmlMoneda = "<i class=\"glyphicon\">S/</i>";
            }
            if (moneda == "MAD")
            {
                htmlMoneda = "<i class=\"glyphicon\">MAD</i>";
            }
            return htmlMoneda;
        }
    }
}