using System.Collections.Generic;
using System.Web.Mvc;

namespace RecruitingWeb.Models
{
    public class ListasModalNecesidadesViewModel
    {
        public IEnumerable<SelectListItem> ClienteList { get; set; }
        public IEnumerable<SelectListItem> ProyectoList { get; set; }
        public IEnumerable<SelectListItem> PerfilList { get; set; }
    }
}