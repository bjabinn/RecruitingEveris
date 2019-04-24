using Recruiting.Application.Base;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class SaveScheduleSegundaEntrevistaResponse : ApplicationResponseBase
    {
        public int EntrevistaId { get; set; }
        public int CandidaturaId { get; set; }
    }
}
