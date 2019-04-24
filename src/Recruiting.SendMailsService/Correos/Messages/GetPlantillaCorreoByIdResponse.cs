using Recruiting.Application.Base;
using Recruiting.SendMailsService.Correos.ViewModels;

namespace Recruiting.SendMailsService.Correos.Messages
{
    public class GetPlantillaCorreoByIdResponse : ApplicationResponseBase
    {
        public CorreoPlantillaRowViewModel correoPlantilla { get; set; }
       
    }
}
