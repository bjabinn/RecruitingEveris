using RecruitingWeb.Components.DataTable.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RecruitingWeb.Components.DataTable.Helpers
{
    public static class DataTablesHelper
    {
        public static GridModel<TModel> InitializeDataTable<TModel>(this HtmlHelper html, IEnumerable<TModel> model)
        {
            return new GridModel<TModel>(model);
        }

        public static GridModel<TModel> InitializeDataTable<TModel>(this HtmlHelper html)
        {
            return new GridModel<TModel>();
        }
    }
}