using Recruiting.Application.Base;
using Recruiting.Application.Candidatos.ViewModels;

namespace Recruiting.Application.Candidatos.Messages
{
    public class CreateCandidatoOtherInfoResponse : ApplicationResponseBase
    {
        public int CandidatoId { get; set; }
    }
}
