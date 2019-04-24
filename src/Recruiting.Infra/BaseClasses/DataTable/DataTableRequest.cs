using System;
using System.Collections.Generic;

namespace Recruiting.Business.BaseClasses.DataTable
{
    [Serializable]
    public class DataTableRequest
    {
        public DataTableRequest() 
        {
            Columns = new List<DataTableColumnSetting>();
        }

        public int? PageSize { get; set; }

        public int PageNumber { get; set; }

        public IEnumerable<DataTableColumnSetting> Columns { get; set; }

        public IDictionary<string, string> CustomFilters { get; set; }
    }
}
