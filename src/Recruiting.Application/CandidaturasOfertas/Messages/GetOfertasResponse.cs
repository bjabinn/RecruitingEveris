using Recruiting.Application.Base;
using Recruiting.Application.CandidaturasOfertas.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.CandidaturasOfertas.Messages
{
    public class GetOfertasResponse : ApplicationResponseBase
    {
        public IEnumerable<OfertaRowViewModel> OfertaRowViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
