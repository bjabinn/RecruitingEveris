using Recruiting.Application.Base;
using Recruiting.Application.Candidaturas.ViewModel;

namespace Recruiting.Application.Candidaturas.Messages
{
    public class GetScheduleCartaOfertaResponse : ApplicationResponseBase
    {
        public AgendarCartaOfertaViewModel AgendarCartaOfertaViewModel { get; set; }
    }
}
