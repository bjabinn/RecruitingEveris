using Recruiting.Application.Base;
using Recruiting.Application.Becarios.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Becarios.Messages
{
    public class GetBecariosExportToExcelResponse : ApplicationResponseBase
    {
        public IEnumerable<BecarioRowExportToExcelViewModel> BecarioRowExportToExcelViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
