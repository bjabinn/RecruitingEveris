using Recruiting.Application.Base;
using Recruiting.Application.Candidaturas.ViewModel;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class GetSegundaEntrevistaResponse : ApplicationResponseBase
    {
        public SegundaEntrevistaViewModel CompletarSegundaEntrevistaViewModel { get; set; }
    }
}
