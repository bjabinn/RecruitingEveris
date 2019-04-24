using Recruiting.Application.Base;
using Recruiting.Application.Ofertas.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Ofertas.Messages
{
    public class GetOfertasNombreIdResponse : ApplicationResponseBase
    {
        public IEnumerable<OfertaNombreIdViewModel> OfertaNombreIdViewModel { get; set; }
    }
}
