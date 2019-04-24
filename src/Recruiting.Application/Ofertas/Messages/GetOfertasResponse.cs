using Recruiting.Application.Base;
using Recruiting.Application.Ofertas.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Ofertas.Messages
{
    public class GetOfertasResponse : ApplicationResponseBase
    {
        public IEnumerable<OfertaRowViewModel> OfertaViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
