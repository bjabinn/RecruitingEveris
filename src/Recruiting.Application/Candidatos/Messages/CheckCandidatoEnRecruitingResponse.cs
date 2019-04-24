using Recruiting.Application.Base;
using Recruiting.Application.Candidatos.ViewModels;

namespace Recruiting.Application.Candidatos.Messages
{
    public class CheckCandidatoEnRecruitingResponse : ApplicationResponseBase
    {
        public bool ExistenteEnRecruiting { get; set; }

        public int? CandidatoId { get; set; }
    }
}
