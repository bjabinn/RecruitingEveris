using Recruiting.Business.BaseClasses.DataTable;
using System.Collections.Generic;
using System.Linq;

namespace RecruitingWeb.Components.DataTable.ServerSide
{
    public static class DataTableMapper
    {
        #region Constants
        #endregion

        #region Mapper
        public static DataTableRequest ConvertToDataTableRequestViewModel(this IDataTablesRequest request)
        {
            if (request == null)
            {
                return null;
            }

            var viewModel = new DataTableRequest 
            {
                PageSize = request.Length > 0 ? request.Length : (int?)null,
                PageNumber = request.Start
            };
            viewModel.Columns = request.ConvertToColumnSettingViewModels();

            viewModel.CustomFilters = request.CustomFilters;

            return viewModel;
        }

        private static IEnumerable<DataTableColumnSetting> ConvertToColumnSettingViewModels(this IDataTablesRequest request)
        {
            if ((request == null) || (request.Columns == null))
            {
                return new List<DataTableColumnSetting>();
            }

            return request.Columns.Select(x => new DataTableColumnSetting 
            {
                Name = string.IsNullOrEmpty(x.Name) ? x.Data : x.Name,
                SortDirection = GetSortDirection(x)
            }).ToList();
        }

        private static DataTableSortDirectionEnum? GetSortDirection(Column column)
        {
            if (!column.IsOrdered)
            {
                return null;
            }

            var direction = DataTableSortDirectionEnum.Ascending;
            if (column.SortDirection == Column.OrderDirection.Descendant)
            {
                direction = DataTableSortDirectionEnum.Descending;
            }
            return direction;
        }
        #endregion
    }
}
