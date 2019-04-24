using Recruiting.Application.Base;

namespace Recruiting.SendMailsService.Correos.Messages
{
    public class GetValorDefectoNombreVariablePlantillaCorreoResponse : ApplicationResponseBase
    {
        public string VarlorDefecto { get; set; }
    }
}
