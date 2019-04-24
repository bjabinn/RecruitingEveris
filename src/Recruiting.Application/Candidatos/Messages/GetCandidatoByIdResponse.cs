using Recruiting.Application.Base;
using Recruiting.Application.Candidatos.ViewModels;

namespace Recruiting.Application.Candidatos.Messages
{
    public class GetCandidatoByIdResponse : ApplicationResponseBase
    {
        public CreateEditCandidatoViewModel CandidatoViewModel { get; set; }
    }
}
