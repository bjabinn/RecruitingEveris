using Recruiting.Application.Base;
using Recruiting.Application.Candidatos.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Candidatos.Messages
{
    public class GetCandidatoCandidaturasModalResponse : ApplicationResponseBase
    {
        public IEnumerable<CandidaturaModalRowViewModel> CandidaturaModalRowViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
