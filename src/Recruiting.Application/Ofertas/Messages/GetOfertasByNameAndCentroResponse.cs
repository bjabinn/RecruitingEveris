using Recruiting.Application.Base;
using Recruiting.Application.Ofertas.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Ofertas.Messages
{
    public class GetOfertasByNameAndCentroResponse : ApplicationResponseBase
    {
        public List<OfertaRowViewModel> Ofertas { get; set; }
    }
}
