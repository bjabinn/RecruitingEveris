using Recruiting.Application.Base;
using Recruiting.Application.Clientes.ViewModels;

namespace Recruiting.Application.Clientes.Messages
{
    public class GetClienteResponse : ApplicationResponseBase
    {
        public ClienteRowViewModel Cliente { get; set; }
    }
}
