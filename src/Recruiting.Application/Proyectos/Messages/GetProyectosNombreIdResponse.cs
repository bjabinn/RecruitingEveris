using Recruiting.Application.Base;
using Recruiting.Application.Proyectos.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Proyectos.Messages
{
    public class GetProyectosNombreIdResponse : ApplicationResponseBase
    {
        public IEnumerable<ProyectoNombreIdViewModel> ProyectoViewModel { get; set; }

        public int TotalElementos { get; set; }
    }
}
