using System;

namespace Recruiting.Business.BaseClasses.DataTable
{
    [Serializable]
    public class DataTableColumnSetting
    {
        public string Name { get; set; }

        public DataTableSortDirectionEnum? SortDirection { get; set; }
    }
}
