using System;
using System.Web.WebPages;

namespace RecruitingWeb.Components.DataTable.Models
{
    public class RowTemplateFactory<TModel>
    {
        private readonly GridModel<TModel> _gridViewModel;

        internal RowTemplateFactory(GridModel<TModel> gridViewModel)
        {
            _gridViewModel = gridViewModel;
        }

        public RowTemplateDefinition<TModel> Create(RowTemplateType templateType, Func<TModel, HelperResult> template)
        {
            var row = new RowTemplateDefinition<TModel>(templateType, template);
            _gridViewModel.RowTemplatesDefinition.Add(row);
            return row;
        }
    }
}