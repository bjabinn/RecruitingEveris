using Recruiting.Application.Base;
using Recruiting.Application.Necesidades.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Necesidades.Messages
{
    public class GetNecesidadesResponse : ApplicationResponseBase
    {
        public IEnumerable<NecesidadRowViewModel> NecesidadViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
