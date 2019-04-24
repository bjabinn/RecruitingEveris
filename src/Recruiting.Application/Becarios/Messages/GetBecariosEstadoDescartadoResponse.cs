using Recruiting.Application.Base;
using Recruiting.Application.Becarios.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Becarios.Messages
{
    public class GetBecariosEstadoDescartadoResponse : ApplicationResponseBase
    {
        public IEnumerable<BecarioRowViewModel> BecarioRowViewModel { get; set; }
    }
}
