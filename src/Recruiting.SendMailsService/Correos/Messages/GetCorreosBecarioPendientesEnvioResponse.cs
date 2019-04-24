using Recruiting.Application.Base;
using Recruiting.SendMailsService.Correos.ViewModels;
using System.Collections.Generic;

namespace Recruiting.SendMailsService.Correos.Messages
{
    public class GetCorreosBecarioPendientesEnvioResponse : ApplicationResponseBase
    {
        public IEnumerable<CorreoBecarioRowViewModel> Correos { get; set; }
    }
}
