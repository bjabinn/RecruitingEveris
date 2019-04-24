using System;
using System.Web.Mvc;
using System.Web.WebPages;

namespace RecruitingWeb.Components.DataTable.Models
{
    public class TemplatedColumn<TModel>:BaseColumn<TModel>
    {
        private readonly Func<TModel, HelperResult> _template;

        public TemplatedColumn(Func<TModel, HelperResult> template)
        {
            _template = template;
        }

        public override MvcHtmlString Value(TModel modelRow)
        {
           return new MvcHtmlString(_template(modelRow).ToString());
        }

        public override MvcHtmlString ResolvedAttributes(TModel modelRow)
        {
            return null;
        }
    }
}
