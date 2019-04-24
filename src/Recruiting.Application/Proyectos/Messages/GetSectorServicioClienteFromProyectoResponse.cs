using Recruiting.Application.Base;

namespace Recruiting.Application.Proyectos.Messages
{
    public class GetSectorServicioClienteFromProyectoResponse : ApplicationResponseBase
    {
        public int? SectorId { get; set; }
        public int? ServicioId { get; set; }
        public int? ClienteId { get; set; }
    }
}
