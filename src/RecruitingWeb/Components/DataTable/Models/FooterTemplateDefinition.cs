using System;
using System.Web.WebPages;

namespace RecruitingWeb.Components.DataTable.Models
{
    public class FooterTemplateDefinition
    {
        public Func<dynamic, HelperResult> Template { get; set; } 

        public FooterTemplateDefinition(Func<dynamic, HelperResult> template)
        {
            Template = template;
        }
    }
}