using Recruiting.Application.Base;
using Recruiting.Application.Proyectos.ViewModels;

namespace Recruiting.Application.Proyectos.Messages
{
    public class GetProyectoResponse : ApplicationResponseBase
    {
        public ProyectoRowViewModel Proyecto { get; set; }
    }
}
