using Recruiting.Application.Base;
using Recruiting.Application.Usuarios.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Usuarios.Messages
{
    public class GetUsuariosByNombreUsuarioResponse : ApplicationResponseBase
    {
        public IEnumerable<UsuarioRowViewModel> Usuarios { get; set; }
    }
}
