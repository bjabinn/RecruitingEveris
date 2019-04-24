using System;
using System.Web.WebPages;

namespace RecruitingWeb.Components.DataTable.Models
{
    public class FootTemplateFactory<TModel>
    {
        private readonly GridModel<TModel> _gridViewModel;

        internal FootTemplateFactory(GridModel<TModel> gridViewModel)
        {
            _gridViewModel = gridViewModel;
        }

        public FooterTemplateDefinition Create(Func<dynamic, HelperResult> template)
        {
            var row = new FooterTemplateDefinition(template);
            _gridViewModel.FootTemplatesDefinition.Add(row);
            return row;
        }
    }
}