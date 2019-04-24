using Recruiting.Application.Base;
using Recruiting.Application.Candidatos.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Candidatos.Messages
{
    public class GetCandidatosQueCumplenPerfilResponse : ApplicationResponseBase
    {
        public IEnumerable<CandidatoQueCumplePerfilRowViewModel> CandidatosQueCumplenPerfilRowViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
