using Recruiting.Application.Base;
using Recruiting.Application.Permisos.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Permisos.Messages
{
    public class GetPermisosResponse : ApplicationResponseBase
    {
        public IEnumerable<PermisoViewModel> PermisoViewModel { get; set; }
    }
}
