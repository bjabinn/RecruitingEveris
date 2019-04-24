using Recruiting.Application.Base;
using Recruiting.Application.Becarios.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Becarios.Messages
{
    public class GetBecariosResponse : ApplicationResponseBase
    {
        public IEnumerable<BecarioRowViewModel> BecarioRowViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
