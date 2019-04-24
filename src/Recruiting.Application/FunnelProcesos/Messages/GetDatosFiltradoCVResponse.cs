using Recruiting.Application.Base;
using Recruiting.Application.FunnelProcesos.ViewModels;

namespace Recruiting.Application.FunnelProcesos.Messages
{
    public class GetDatosFiltradoCVResponse : ApplicationResponseBase
    {
        public DatosFiltradoCVViewModel DatosFiltradoCV { get; set; }
    }
}
