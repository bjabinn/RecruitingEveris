using Recruiting.Application.Base;
using Recruiting.Application.Candidaturas.ViewModel;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class GetFiltroEnSesionResponse : ApplicationResponseBase 
    {
        public CandidaturaFiltroViewModel Filtro { get; set; }
    }
}
