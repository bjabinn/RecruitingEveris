using System;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    [Serializable]
    public class AgendarCartaOferta
    {
        public int CandidaturaId { get; set; } 
        public int? EntrevistadorId { get; set; }
        public string EntrevistadorName { get; set; }
        public DateTime? FechaAgendarCarta { get; set; }
        public int? OficinaId { get; set; }
        public string PlantillaCorreoNombre { get; set; }

        public int? AccessEtapa { get; set; }
        public string AccessAgendarCarta { get; set; }
        public string NombreCandidato { get; set; }
    }
}
