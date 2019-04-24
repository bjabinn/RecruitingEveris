using System;

namespace Recruiting.Application.Roles.ViewModels
{
    [Serializable]
    public class PermisoRolViewModel
    {
        public int PermisoId { get; set; }
        public int RolId { get; set; }
        public string PermisoNombre { get; set; }
        public bool ContienePermiso { get; set; }
    }
}
