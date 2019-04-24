using Recruiting.Application.Base;
using Recruiting.Application.FunnelProcesos.ViewModels;

namespace Recruiting.Application.FunnelProcesos.Messages
{
    public class GetDatosEntrevistasResponse : ApplicationResponseBase
    {
        public DatosEntrevistasViewModel DatosEntrevistas { get; set; }
    }
}
