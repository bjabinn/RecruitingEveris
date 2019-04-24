using Recruiting.Application.Base;
using Recruiting.Application.FunnelProcesos.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.FunnelProcesos.Messages
{
    public class GetDatosDesgloseTecnologiaCategoriaResponse : ApplicationResponseBase
    {
        public List<DesgloseTecnologiaCategoriaViewModel> ListaDesgloseTecnologiaCategoria { get; set; }

        public int TotalElementos { get; set; }
    }
}
