using System;

namespace Recruiting.Application.FunnelProcesos.ViewModels
{
    public class FiltroFunnelProcesosViewModel
    {
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? TipoTecnologiaId { get; set; }
        public int? TipoCategoriaId { get; set; }
        public int? CentroIdUsuario { get; set; }
        public int? CandidaturaOfertaId { get; set; }

    }
}
