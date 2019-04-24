using Recruiting.Application.Candidaturas.ViewModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecruitingWeb.Models
{
    public class DatosCandidatoConsultaApiModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string NIF { get; set; }      


    }
}