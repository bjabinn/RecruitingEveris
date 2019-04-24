using Recruiting.Application.Base;
using Recruiting.Application.Necesidades.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Necesidades.Messages
{
    public class GetGruposNecesidadesResponse : ApplicationResponseBase
    {
        public IEnumerable<GrupoNecesidadesRowViewModel> GrupoNecesidadesRowViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
