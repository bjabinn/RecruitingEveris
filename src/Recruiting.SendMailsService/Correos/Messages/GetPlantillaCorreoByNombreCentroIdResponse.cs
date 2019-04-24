using Recruiting.Application.Base;
using Recruiting.SendMailsService.Correos.ViewModels;

namespace Recruiting.SendMailsService.Correos.Messages
{
    public class GetPlantillaCorreoByNombreCentroIdResponse : ApplicationResponseBase
    {
        public CorreoPlantillaRowViewModel correoPlantilla { get; set; }
    }
}
