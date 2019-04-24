using Recruiting.Application.Base;
using Recruiting.Application.Candidaturas.ViewModel;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class GetScheduleSegundaEntrevistaResponse : ApplicationResponseBase
    {
        public AgendarSegundaEntrevistaViewModel AgendarSegundaEntrevistaViewModel { get; set; }
    }
}
