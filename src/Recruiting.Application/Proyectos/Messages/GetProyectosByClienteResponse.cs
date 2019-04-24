using Recruiting.Application.Base;
using Recruiting.Application.Proyectos.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Proyectos.Messages
{
    public class GetProyectosByClienteResponse : ApplicationResponseBase
    {
        public IEnumerable<ProyectoRowViewModel> ProyectoViewModel { get; set; }
    }
}
