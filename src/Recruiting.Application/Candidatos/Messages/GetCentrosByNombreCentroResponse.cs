using Recruiting.Application.Base;
using Recruiting.Application.Becarios.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Candidatos.Messages
{
    public class GetCentrosByNombreCentroResponse : ApplicationResponseBase
    {
        public IEnumerable<CentroProcedenciaRowViewModel> CentrosProcedencia { get; set; }
    }
}
