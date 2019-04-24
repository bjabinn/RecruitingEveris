using Recruiting.Application.Base;
using Recruiting.SendMailsService.Correos.ViewModels;

namespace Recruiting.SendMailsService.Correos.Messages
{
    public class GetTextoFormateadoMeetingResponse : ApplicationResponseBase
    {
        public string TextoFormateado { get; set; }
    }
}
