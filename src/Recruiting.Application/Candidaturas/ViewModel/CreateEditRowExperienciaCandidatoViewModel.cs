using System;

namespace Recruiting.Application.Candidaturas.ViewModels
{
    public class CreateEditRowExperienciaCandidatoViewModel
    {

        public int? CandidatoExperienciaId { get; set; }

        public int CandidatoId { get; set; }

        public int TipoTecnologiaId { get; set; }

        public string TipoTecnologia { get; set; }

        public int NivelTecnologiaId { get; set; }

        public string NivelTecnologia { get; set; }

        public int Experiencia { get; set; }
    
    }
}
