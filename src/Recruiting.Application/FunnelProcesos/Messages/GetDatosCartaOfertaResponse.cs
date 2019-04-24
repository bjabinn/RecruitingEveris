using Recruiting.Application.Base;
using Recruiting.Application.FunnelProcesos.ViewModels;

namespace Recruiting.Application.FunnelProcesos.Messages
{
    public class GetDatosCartaOfertaResponse : ApplicationResponseBase
    {
        public DatosCartaOfertaViewModel DatosCartaOferta { get; set; }
    }
}
