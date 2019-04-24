using Recruiting.Application.Base;
using Recruiting.Application.PersonasLibres.ViewModels;

namespace Recruiting.Application.PersonasLibres.Messages
{
    public class GetListEmpleadosFenixCategoriaLineaCeldaResponse : ApplicationResponseBase
    {
        public EmpleadosFenixListCategoriaLineaCeldaviewModel EmpleadosFenixListCategoriaLineaCeldaviewModel { get; set; }
    }
}
