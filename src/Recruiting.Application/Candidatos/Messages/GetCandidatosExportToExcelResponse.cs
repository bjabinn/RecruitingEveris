using Recruiting.Application.Base;
using Recruiting.Application.Candidatos.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Candidatos.Messages
{
    public class GetCandidatosExportToExcelResponse : ApplicationResponseBase
    {
        public IEnumerable<CandidatoRowExportToExcelViewModel> CandidatoRowExportToExcelViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
