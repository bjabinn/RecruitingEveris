using System.ComponentModel.DataAnnotations;

namespace EverisUserValidator.Models
{
    public class UserViewModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }
}