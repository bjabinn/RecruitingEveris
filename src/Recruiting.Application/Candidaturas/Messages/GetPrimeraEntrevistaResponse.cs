using Recruiting.Application.Base;
using Recruiting.Application.Candidaturas.ViewModel;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class GetPrimeraEntrevistaResponse : ApplicationResponseBase
    {
        public PrimeraEntrevistaViewModel CompletarPrimeraEntrevistaViewModel { get; set; }
    }
}
