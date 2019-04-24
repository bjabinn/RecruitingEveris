using System;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    [Serializable]
    public class AgendarSegundaEntrevista
    {
        public int CandidaturaId { get; set; }
        public int? EntrevistadorId { get; set; }
        public string EntrevistadorName { get; set; }
        public DateTime? FechaEntrevista { get; set; }
        public bool Presencial { get; set; }
        public bool AvisarAlCandidato { get; set; }
        public int? OficinaId { get; set; }
        public string PlantillaCorreoNombre { get; set; }
        public string NombreCandidato { get; set; }
    }
}
