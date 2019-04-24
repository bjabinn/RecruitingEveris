using Recruiting.Application.Base;
using Recruiting.Application.Usuarios.ViewModels;

namespace Recruiting.Application.Usuarios.Messages
{
    public class GetUsuarioRolPermisoResponse : ApplicationResponseBase
    {
        public UsuarioRolPermisoViewModel UsuarioRolPermisoViewModel { get; set; }
    }
}
