using Recruiting.Application.Base;
using Recruiting.SendMailsService.Correos.ViewModels;
using System.Collections.Generic;

namespace Recruiting.SendMailsService.Correos.Messages
{
    public class GetCorreosPendientesEnvioResponse : ApplicationResponseBase
    {
        public IEnumerable<CorreoRowViewModel> Correos { get; set; }
    }
}
