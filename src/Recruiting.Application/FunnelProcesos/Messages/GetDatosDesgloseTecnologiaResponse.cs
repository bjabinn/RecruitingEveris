using Recruiting.Application.Base;
using Recruiting.Application.FunnelProcesos.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.FunnelProcesos.Messages
{
    public class GetDatosDesgloseTecnologiaResponse : ApplicationResponseBase
    {
        public List<DesgloseTecnologiaViewModel> ListaDesgloseTecnologia { get; set; }

        public int TotalElementos { get; set; }
    }
}
