using System.ComponentModel.DataAnnotations;


namespace RecruitingWeb.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }


        [Display(Name = "Recuérdame")]
        public bool RememberMe { get; set; }

        public bool errorLogin { get; set; }
    }
}
