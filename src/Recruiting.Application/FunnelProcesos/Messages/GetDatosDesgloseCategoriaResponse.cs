using Recruiting.Application.Base;
using Recruiting.Application.FunnelProcesos.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.FunnelProcesos.Messages
{
    public class GetDatosDesgloseCategoriaResponse : ApplicationResponseBase
    {
        public List<DesgloseCategoriaViewModel> ListaDesgloseCategoria { get; set; }

        public int TotalElementos { get; set; }
    }
}
