using System;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    [Serializable]
    public class CandidaturaDatosCandidatos
    {
        public int? CandidaturaId { get; set; }
        public int? CandidatoId { get; set; }

        public String Nombres { get; set; }
        public String Apellidos { get; set; }

        public int TipoIdentificacionId { get; set; }
        public String NumeroIdentificacion { get; set; }
    }
}
