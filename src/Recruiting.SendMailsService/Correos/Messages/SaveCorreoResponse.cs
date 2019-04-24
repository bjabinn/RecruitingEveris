using Recruiting.Application.Base;

namespace Recruiting.SendMailsService.Correos.Messages
{
    public class SaveCorreoResponse : ApplicationResponseBase
    {
        public int CorreoId { get; set; }
        public int PlantillaId { get; set; }
    }
}
