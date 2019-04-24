using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RecruitingWeb.Models
{
    public class OtherInfoDropdownsModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        public IEnumerable<SelectListItem> TitulacionList { get; set; }
        public IEnumerable<SelectListItem> PerfilList { get; set; }
        public IEnumerable<SelectListItem> TecnologiaList { get; set; }
        public IEnumerable<SelectListItem> ModuloList { get; set; }

    }
}