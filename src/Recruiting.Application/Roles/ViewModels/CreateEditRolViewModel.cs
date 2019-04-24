using Recruiting.Application.Usuarios.ViewModels;
using System;
using System.Collections.Generic;

namespace Recruiting.Application.Roles.ViewModels
{
    [Serializable]
    public class CreateEditRolViewModel
    {
        public int RolId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<UsuarioRolViewModel> UsuarioRol { get; set; }
        public virtual ICollection<PermisoRolViewModel> PermisoRol { get; set; } 
        public bool Activo { get; set; }
    }
}
