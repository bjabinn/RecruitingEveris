using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.PersonasLibres.ViewModels
{
    public class PersonasLibresToCreateViewModel
    {
        public List<PersonaLibreRowViewModel> PersonaLibreRowViewModelList { get; set; }
        public IEnumerable<SelectListItem> ListaTecnologias { get; set; }
        public IEnumerable<SelectListItem> NivelIdiomaList { get; set; }
    }
}
