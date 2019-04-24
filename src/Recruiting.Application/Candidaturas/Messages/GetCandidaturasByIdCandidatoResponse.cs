using Recruiting.Application.Base;
using Recruiting.Application.Candidaturas.ViewModel;
using System.Collections.Generic;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class GetCandidaturasByIdCandidatoResponse : ApplicationResponseBase 
    {
        public IEnumerable<CandidaturaViewModel> CandidaturasViewModel { get; set; }
      
    }
}
