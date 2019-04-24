using Recruiting.Application.Base;
using Recruiting.Application.Candidaturas.ViewModel;
using System.Collections.Generic;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class GetEtapasCandidaturaResponse : ApplicationResponseBase
    {
        public IEnumerable<CandidaturaEtapaRowViewModel> CandidaturaEtapasViewModel { get; set; }
    }
}
