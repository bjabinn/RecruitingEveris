using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    public class DatosCandidaturaOtherInfoViewModel
    { 
        public int CategoriaId { get; set; }
        public int TecnologiaId { get; set; }
        public int? ModuloId { get; set; }
        public int OrigenCvId { get; set; }
        public int? FuenteReclutamientoId { get; set; }

        public int CandidatoId { get; set; }
        public int UsuarioCreacionOtherInfo { get; set; }
    }
}