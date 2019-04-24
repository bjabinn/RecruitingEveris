using System;

namespace Recruiting.Application.Candidatos.ViewModels
{
    [Serializable]
    public class CandidatoRowExportToExcelViewModel
    {
        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string NumeroIdentificacion { get; set; }

        public string Titulacion { get; set; }
        
        public string FechaNacimiento { get; set; }

        public int numCandidaturasAsociadas { get; set; }
        public string CentroEducativo { get; set; }
        public string AnioRegresado { get; set; }

        public string Centro { get; set; }
        public string NivelIngles { get; set; }
    }
}
