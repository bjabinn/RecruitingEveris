using System;
using System.Collections.Generic;

namespace Recruiting.Application.Roles.ViewModels
{
    [Serializable]
    public class RolRowViewModel
    {
        public int RolId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ICollection<PermisoRolViewModel> Permisos { get; set; }
    }
}
