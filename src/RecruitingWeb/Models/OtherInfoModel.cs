using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecruitingWeb.Models
{
    public class OtherInfoModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        public List<OtherInfoRowModel> OtherInfoList { get; set; }


    }
}