using System;
using System.Web.WebPages;

namespace RecruitingWeb.Components.DataTable.Models
{
    public class RowTemplateDefinition<TModel>
    {
        public RowTemplateType RowTemplateType { get; set; }
        public Func<TModel, HelperResult> Template { get; set; } 

        public RowTemplateDefinition(RowTemplateType rowTemplateType, Func<TModel, HelperResult> template)
        {
            RowTemplateType = rowTemplateType;
            Template = template;
        }
    }
}