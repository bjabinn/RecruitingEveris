using Recruiting.Application.Base;
using Recruiting.Application.Candidatos.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Candidatos.Messages
{
    public class GetCandidatosResponse : ApplicationResponseBase
    {
        public IEnumerable<CandidatoRowViewModel> CandidatoRowViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
