using System;

namespace Recruiting.Application.Candidatos.ViewModels
{
    [Serializable]
    public class CandidatoQueCumplePerfilRowViewModel
    {

        public int CandidatoId { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string NumeroIdentificacion { get; set; }

        public int candidaturaIdAsociado { get; set; }

        public bool IsActivo { get; set; }
        
        public string Centro { get; set; }

        public string EtapaCandidatura { get; set; }
    }
}
