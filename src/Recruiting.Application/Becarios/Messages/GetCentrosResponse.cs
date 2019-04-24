using Recruiting.Application.Base;
using Recruiting.Application.Becarios.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Becarios.Messages
{
    public class GetCentrosResponse : ApplicationResponseBase
    {
        public IEnumerable<CentroProcedenciaRowViewModel> CentroRowViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
