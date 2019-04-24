using Recruiting.Application.Base;
using Recruiting.Application.Candidatos.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Candidatos.Messages
{
    public class GetCandidatoBecariosModalResponse : ApplicationResponseBase
    {
        public IEnumerable<BecarioModalRowViewModel> BecarioModalRowViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
