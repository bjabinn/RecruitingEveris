using System.Collections.Generic;
using System.Web.Mvc;

namespace RecruitingWeb.Models
{
    public class EstadoNecesidadSelectViewModel
    {
        public IEnumerable<SelectListItem> NecesidadPreasignadaOCerrada { get; set; }
    }
}