using Recruiting.Application.Base;
using Recruiting.Application.Ofertas.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.Ofertas.Messages
{
    public class GetOfertasExportToExcelResponse : ApplicationResponseBase
    {
        public IEnumerable<OfertaRowExportToExcelViewModel> OfertaViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
