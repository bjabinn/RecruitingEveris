using Recruiting.Application.Base;
using Recruiting.Application.FunnelProcesos.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.FunnelProcesos.Messages
{
    public class GetCandidaturasModalResponse : ApplicationResponseBase
    {
        public IEnumerable<CandidaturaModalRowViewModel> CandidaturaModalViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
