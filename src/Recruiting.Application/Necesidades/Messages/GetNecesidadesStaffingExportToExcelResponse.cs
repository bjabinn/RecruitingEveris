using Recruiting.Application.Base;
using Recruiting.Application.Necesidades.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Necesidades.Messages
{
    public class GetNecesidadesStaffingExportToExcelResponse : ApplicationResponseBase
    {
        public IEnumerable<NecesidadStaffingRowExportToExcelViewModel> NecesidadStaffingExportToExcelViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
