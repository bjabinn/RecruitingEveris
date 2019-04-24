using Recruiting.Application.Base;
using Recruiting.Application.Clientes.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Clientes.Messages
{
    public class GetClientesResponse : ApplicationResponseBase
    {
        public IEnumerable<ClienteRowViewModel> ClienteViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
