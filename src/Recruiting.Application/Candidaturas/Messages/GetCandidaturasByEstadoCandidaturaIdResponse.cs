using Recruiting.Application.Base;
using Recruiting.Application.Candidaturas.ViewModel;
using System.Collections.Generic;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class GetCandidaturasByEstadoCandidaturaIdResponse : ApplicationResponseBase 
    {
        public IEnumerable<CandidaturaRowViewModel> CandidaturasViewModel { get; set; }
      
    }
}
