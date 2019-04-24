using System;

namespace Recruiting.Application.Candidatos.ViewModels
{
    [Serializable]
    public class CandidatoOtherInfoViewModel
    {
        public int? CandidatoId { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string NIF { get; set; }

        public string Telefono { get; set; }

        public string Email  { get; set; }

        public int  TitulacionId { get; set; }

        public int UsuarioCreacionOtherInfo { get; set; }

    }
}
