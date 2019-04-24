using System;
using System.Collections.Generic;

namespace Recruiting.Application.Usuarios.ViewModels
{
    [Serializable]
    public class UsuarioRowViewModel
    {
        public int UsuarioId { get; set; }
        public string Usuario { get; set; }
        public string UserName { get; set; }
        public ICollection<UsuarioRolViewModel> Roles { get; set; }
        public int? CentroId { get; set; }
    }
}
