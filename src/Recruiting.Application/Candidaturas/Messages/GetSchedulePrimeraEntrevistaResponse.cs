using Recruiting.Application.Base;
using Recruiting.Application.Candidaturas.ViewModel;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class GetSchedulePrimeraEntrevistaResponse : ApplicationResponseBase
    {
        public AgendarPrimeraEntrevistaViewModel AgendarPrimeraEntrevistaViewModel { get; set; }
    }
}
