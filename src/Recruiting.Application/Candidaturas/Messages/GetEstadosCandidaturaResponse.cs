using Recruiting.Application.Base;
using Recruiting.Application.Candidaturas.ViewModel;
using System.Collections.Generic;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class GetEstadosCandidaturaResponse : ApplicationResponseBase
    {
        public IEnumerable<CandidaturaEstadoRowViewModel> CandidaturaEstadosViewModel { get; set; }
    }
}
