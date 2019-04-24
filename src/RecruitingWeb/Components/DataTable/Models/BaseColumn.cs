using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RecruitingWeb.Components.DataTable.Models
{
    public abstract class BaseColumn<TModel>
    {
        protected BaseColumn()
        {
            Attributes = new Dictionary<string, Func<TModel, string>>();
        }

        public string Header { get; set; }
        public bool Hidden { get; set; }
        public bool Orderable { get; set; }
        public string CssClass { get; set; }
        public string CssHeaderClass { get; set; }
        public string ColumnName { get; set; }

        public Dictionary<string, Func<TModel, string>> Attributes { get; private set; }

        public abstract MvcHtmlString Value(TModel modelRow);

        public abstract MvcHtmlString ResolvedAttributes(TModel modelRow);
    }
}