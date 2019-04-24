using Recruiting.Application.Base;
using Recruiting.Application.Becarios.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Becarios.Messages
{
    public class GetConvocatoriasByNombreResponse : ApplicationResponseBase
    {
        public IEnumerable<ConvocatoriaRowViewModel> Convocatorias { get; set; }
    }
}
