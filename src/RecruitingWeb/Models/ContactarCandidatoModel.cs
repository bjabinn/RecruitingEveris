using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecruitingWeb.Models
{
    public class ContactarCandidatoModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NIF { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int TitulacionId { get; set; }
        public int CategoriaId { get; set; }
        public int TecnologiaId { get; set; }
        public int ? ModuloId { get; set; }
        public int UsuarioCreacionOtherInfo { get; set; }
    }
}