using Recruiting.Application.Base;
using Recruiting.Application.Usuarios.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Usuarios.Messages
{
    public class GetUsuariosResponse : ApplicationResponseBase
    {
        public IEnumerable<UsuarioRowViewModel> UsuarioViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
