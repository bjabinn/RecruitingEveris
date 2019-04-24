using Recruiting.Application.Base;
using Recruiting.Application.PersonasLibres.ViewModels;
using System.Collections.Generic;

namespace Recruiting.Application.PersonasLibres.Messages
{
    public class GetPersonasLibresExportToExcelResponse : ApplicationResponseBase
    {
        public IEnumerable<PersonaLibreRowExportToExcelViewModel> PersonaLibreRowExportToExcelViewModel { get; set; }
        public int TotalElementos { get; set; }
    }
}
