using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.Proyectos.ViewModels
{
    [Serializable]
    public class ProyectoRowViewModel
    {
        public int ProyectoId { get; set; }
        public string Nombre { get; set; }

        public int CentroId { get; set; }
        public string Centro { get; set; }

        public int ClienteId { get; set; }
        public string Cliente { get; set; }

        public string Persona { get; set; }
        public string CuentaCargo { get; set; }

        public int? SectorId { get; set; }
        public int? ServicioId { get; set; }

        public IEnumerable<SelectListItem> SectorList { get; set; }
        public IEnumerable<SelectListItem> ServicioList { get; set; }

        public bool Activo { get; set; }
    }
}
