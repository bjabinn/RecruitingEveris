using Recruiting.Application.Base;
using Recruiting.Application.Necesidades.ViewModel;
using System.Collections.Generic;

namespace Recruiting.Application.Necesidades.Messages
{
    public class GetNecesidadesGrupoExportToExcellResponse : ApplicationResponseBase
    {
        public IEnumerable<NecesidadGrupoRowExportToExcelViewModel> NecesidadGrupoExportToExcellViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
