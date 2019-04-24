using Recruiting.Application.Base;
using Recruiting.Application.Decisiones.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Decisiones.Messages
{
    public class GetTipoDecisionListByEtapaIdResponse : ApplicationResponseBase
    {
        public IEnumerable<TipoDecisionRowViewModel> TipoDecisionViewModel { get; set; }
    }
}
