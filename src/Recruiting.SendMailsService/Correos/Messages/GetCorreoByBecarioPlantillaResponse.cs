using Recruiting.Application.Base;
using Recruiting.SendMailsService.Correos.ViewModels;
using System.Collections.Generic;

namespace Recruiting.SendMailsService.Correos.Messages
{
    public class GetCorreoByBecarioPlantillaResponse : ApplicationResponseBase
    {
        public IEnumerable<CorreoBecarioRowViewModel> Correos { get; set; }
        public int TotalElementos { get; set; }
    }
}
