using Recruiting.Application.Base;

namespace Recruiting.Application.BitacorasBecarios.Messages
{
    public class GetLastEstadoBitacoraByBecarioIdResponse : ApplicationResponseBase
    {  
        public int EstadoAnteriorId { get; set; }
    }
}
