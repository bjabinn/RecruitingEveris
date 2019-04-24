using System;

namespace Recruiting.Application.Candidatos.ViewModels
{
    [Serializable]
    public class CreateEditRowContactoCandidatoViewModel
    {

        public int? CandidatoContactoId { get; set; }

        public int CandidatoId { get; set; }

        public int TipoMedioContactoId { get; set; }

        public string TipoMedioContacto { get; set; }

        public string ValorContacto { get; set; }
    
    }
}
