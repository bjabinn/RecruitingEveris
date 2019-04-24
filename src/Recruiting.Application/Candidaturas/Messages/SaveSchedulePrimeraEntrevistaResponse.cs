using Recruiting.Application.Base;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class SaveSchedulePrimeraEntrevistaResponse : ApplicationResponseBase
    {
        public int EntrevistaId { get; set; }
        public int CandidaturaId { get; set; }
        
    }
}
