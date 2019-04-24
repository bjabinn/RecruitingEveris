using Recruiting.Application.Base;
using Recruiting.Application.Graph.ViewModels;

namespace Recruiting.Application.Graph.Messages
{
    public class GetTokenByIdResponse : ApplicationResponseBase
    {
        public CuentaTokenViewModel cuentaToken { get; set; }
    }
}