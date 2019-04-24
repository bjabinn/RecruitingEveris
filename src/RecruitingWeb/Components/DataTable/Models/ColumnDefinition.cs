using System;

namespace RecruitingWeb.Components.DataTable.Models
{
    public class ColumnDefinition<TModel>
    {
        private readonly BaseColumn<TModel> _column;

        protected internal ColumnDefinition(BaseColumn<TModel> column)
        {
            _column = column;
        }

        public ColumnDefinition<TModel> Header(string header)
        {
            _column.Header = header;
            return this;
        }

        public ColumnDefinition<TModel> Hidden(bool hidden)
        {
            _column.Hidden = hidden;
            return this;
        }

        public ColumnDefinition<TModel> CssClass(string cssClass)
        {
            _column.CssClass = cssClass;
            return this;
        }

        public ColumnDefinition<TModel> CssHeaderClass(string cssHeaderClass)
        {
            _column.CssHeaderClass = cssHeaderClass;
            return this;
        }

        public ColumnDefinition<TModel> Attribute(string attribute, Func<TModel, string> expression)
        {
            _column.Attributes[attribute] = expression;
            return this;
        }

        public ColumnDefinition<TModel> Orderable(bool orderable)
        {
            _column.Orderable = orderable;
            return this;
        }

        public ColumnDefinition<TModel> ColumnName(string columnName)
        {
            _column.ColumnName = columnName;
            return this;
        }
    }
}