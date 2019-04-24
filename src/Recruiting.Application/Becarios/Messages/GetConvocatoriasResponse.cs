using Recruiting.Application.Base;
using Recruiting.Application.Becarios.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Becarios.Messages
{
    public class GetConvocatoriasResponse : ApplicationResponseBase
    {
        public IEnumerable<ConvocatoriaRowViewModel> ConvocatoriaRowViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
