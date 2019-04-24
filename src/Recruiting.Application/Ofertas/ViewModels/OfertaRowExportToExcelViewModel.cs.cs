using System;
using System.ComponentModel.DataAnnotations;

namespace Recruiting.Application.Ofertas.ViewModels
{
    [Serializable]
    public class OfertaRowExportToExcelViewModel
    {
        public string Nombre { get; set; }

        [Display(Name = "Candidatos Inscritos")]
        public int? Candidatos { get; set; }

        public string Estado { get; set; }

        [Display(Name = "Fecha Publicación")]
        public string FechaPublicacion { get; set; }

        public string Centro { get; set; }


       

         

 
 

    }
}
