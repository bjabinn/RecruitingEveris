using Recruiting.Application.Base;
using Recruiting.SendMailsService.Correos.ViewModels;

namespace Recruiting.Application.Correos.Messages
{
    public class GetCorreoByIdResponse : ApplicationResponseBase
    {
        public CorreoRowViewModel CorreoViewModel { get; set; }
    }
}
