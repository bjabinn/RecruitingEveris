using System;

namespace RecruitingWeb.Models
{
    public class FiltroOfertaModels
    {
        public int? OfertaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaEntre { get; set; }
        public DateTime? FechaHasta { get; set; }
        public int EstadoOfertaId { get; set; }

        public int? CentroIdUsuario { get; set; }

        public string Buscar { get; set; }

    }
}