using Recruiting.Application.Base;
using Recruiting.Application.Candidaturas.ViewModel;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class GetFiltradoCVCandidaturaResponse : ApplicationResponseBase
    {
        public CandidaturaFiltradoCvViewModel CandidaturaFiltradoCvViewModel { get; set; }
    }
}
