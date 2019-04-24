using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.Necesidades.ViewModels
{
    public class ModalEdicionPerfilViewModel
    {
        public IEnumerable<SelectListItem> Perfil { get; set; }
        public IEnumerable<SelectListItem> Contratacion { get; set; }
        public IEnumerable<SelectListItem> Prevision { get; set; }
        public IEnumerable<SelectListItem> Estado { get; set; }
        public IEnumerable<SelectListItem> Tecnologia { get; set; }
        public IEnumerable<SelectListItem> Modulo { get; set; }
        public IEnumerable<SelectListItem> Servicio { get; set; }



    }
}