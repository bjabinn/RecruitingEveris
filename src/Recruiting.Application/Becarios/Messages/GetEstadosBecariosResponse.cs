using Recruiting.Application.Base;
using Recruiting.Application.Becarios.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Becarios.Messages
{
    public class GetEstadosBecariosResponse : ApplicationResponseBase
    {
        public IEnumerable<BecarioEstadoRowViewModel> BecarioEstadoViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
