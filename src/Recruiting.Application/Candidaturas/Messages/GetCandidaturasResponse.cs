using Recruiting.Application.Base;
using Recruiting.Application.Candidaturas.ViewModel;
using System.Collections.Generic;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class GetCandidaturasResponse : ApplicationResponseBase
    {
        public IEnumerable<CandidaturaRowViewModel> CandidaturaViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
