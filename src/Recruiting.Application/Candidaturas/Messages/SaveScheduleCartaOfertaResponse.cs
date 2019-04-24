using Recruiting.Application.Base;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class SaveScheduleCartaOfertaResponse : ApplicationResponseBase
    {
        public int CartaOfertaId { get; set; }
        public int CandidaturaId { get; set; }
    }
}
