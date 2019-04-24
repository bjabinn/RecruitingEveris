using Recruiting.Application.Base;
using Recruiting.Application.Candidaturas.ViewModel;
using System.Collections.Generic;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class GetCandidaturasExportToExcelResponse : ApplicationResponseBase
    {
        public IEnumerable<CandidaturaRowExportToExcelViewModel> CandidaturaExportToExcelViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
