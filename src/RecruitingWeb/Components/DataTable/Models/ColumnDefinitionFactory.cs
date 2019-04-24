using System;
using System.Web.WebPages;

namespace RecruitingWeb.Components.DataTable.Models
{
    public class ColumnDefinitionFactory<TModel>
    {
        private readonly GridModel<TModel> _gridViewModel;

        internal ColumnDefinitionFactory(GridModel<TModel> gridViewModel)
        {
            _gridViewModel = gridViewModel;
        }

        public ColumnDefinition<TModel> Bound<TValue>(Func<TModel, TValue> expression, Func<TValue, string> formatExpression = null)
        {
            var column = new Column<TModel, TValue>(expression, formatExpression);
            _gridViewModel.ColumnsData.Add(column);
            return new ColumnDefinition<TModel>(column);
        }

        public ColumnDefinition<TModel> Template(Func<TModel, HelperResult> template)
        {
            var column = new TemplatedColumn<TModel>(template);
            _gridViewModel.ColumnsData.Add(column);
            return new ColumnDefinition<TModel>(column);
        }
    }
}