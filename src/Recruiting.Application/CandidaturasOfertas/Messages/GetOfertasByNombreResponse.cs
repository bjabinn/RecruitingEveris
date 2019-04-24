using Recruiting.Application.Base;
using Recruiting.Application.CandidaturasOfertas.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.CandidaturasOfertas.Messages
{
    public class GetOfertasByNombreResponse : ApplicationResponseBase
    {
        public IEnumerable<OfertaRowViewModel> Ofertas { get; set; }
    }
}
