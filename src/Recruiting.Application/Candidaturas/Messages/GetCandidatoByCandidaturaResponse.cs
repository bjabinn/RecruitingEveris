using Recruiting.Application.Base;
using Recruiting.Application.Candidatos.ViewModels;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class GetCandidatoByCandidaturaResponse : ApplicationResponseBase
    {
        public CreateEditCandidatoViewModel CreateEditCandidatoViewModel { get; set; }
    }
}
