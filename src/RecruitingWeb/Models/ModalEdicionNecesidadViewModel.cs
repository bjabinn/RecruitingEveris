using System.Collections.Generic;
using System.Web.Mvc;

namespace RecruitingWeb.Models
{
    public class ModalEdicionNecesidadViewModel
    {
        public IEnumerable<SelectListItem> Oficina { get;set; }
        public IEnumerable<SelectListItem> Sector { get; set; }
        public IEnumerable<SelectListItem> Cliente { get; set; }
        public IEnumerable<SelectListItem> Proyecto { get; set; }
        public IEnumerable<SelectListItem> Tecnologia { get; set; }
        public IEnumerable<SelectListItem> Servicio { get; set; }
        public IEnumerable<SelectListItem> Perfil { get; set; }
        public IEnumerable<SelectListItem> Duracion { get; set; }
        public IEnumerable<SelectListItem> Contratacion { get; set; }
        public IEnumerable<SelectListItem> Prevision { get; set; }
        public IEnumerable<SelectListItem> Modulo { get; set; }
        public IEnumerable<SelectListItem> Estado { get; set; }


    }
}