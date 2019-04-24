using Recruiting.Application.Base;
using Recruiting.Application.Candidaturas.ViewModel;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class GetCartaOfertaIdByCandidaturaIdResponse : ApplicationResponseBase
    {
        public int CartaOfertaId { get; set; }
    }
}
