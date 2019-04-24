using System;

namespace Recruiting.Application.Candidatos.ViewModels
{
    [Serializable]
    public class CandidatoRowViewModel
    {

        public int CandidatoId { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string NumeroIdentificacion { get; set; }

        public string Titulacion { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public int? NumCandidaturasAsociadas { get; set; }

        public bool CVAvailable { get; set; }      

        public bool CandidaturaAvailable { get; set; }

        public bool IsActivo { get; set; }
        
        public string Centro { get; set; }

        public string NivelIdioma { get; set; }

        public bool ExistenCandidaturas { get; set; }
        public bool ExistenBecarios { get; set; }
    }
}
