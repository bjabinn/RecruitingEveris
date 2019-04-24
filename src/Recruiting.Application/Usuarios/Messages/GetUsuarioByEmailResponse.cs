using Recruiting.Application.Base;
using Recruiting.Application.Usuarios.ViewModels;

namespace Recruiting.Application.Usuarios.Messages
{
    public class GetUsuarioByEmailResponse : ApplicationResponseBase
    {
        public CreateEditUsuarioViewModel UsuarioViewModel { get; set; }
    }
}
