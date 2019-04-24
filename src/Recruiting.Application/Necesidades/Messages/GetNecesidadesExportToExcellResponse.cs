using Recruiting.Application.Base;
using Recruiting.Application.Necesidades.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Necesidades.Messages
{
    public class GetNecesidadesExportToExcellResponse : ApplicationResponseBase
    {
        public IEnumerable<NecesidadRowExportToExcelViewModel> NecesidadExportToExcellViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
