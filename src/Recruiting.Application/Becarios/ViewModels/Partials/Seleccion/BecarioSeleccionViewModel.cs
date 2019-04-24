using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.Becarios.ViewModels
{
    [Serializable]
    public class BecarioSeleccionViewModel
    {
        public BecarioGestionDocumentalViewModel BecarioGestionDocumental { get; set; }
        public BecarioAsignacionViewModel BecarioAsignacion { get; set; }      

        public int? BecarioId { get; set; }
        public bool CompletadoGestion { get; set; }
        public bool CompletadoAsignacion { get; set; }

        public IEnumerable<SelectListItem> TipoAsistenciaList { get; set; }
        public IEnumerable<SelectListItem> ClienteList { get; set; }
        public IEnumerable<SelectListItem> ProyectoList { get; set; }
        public string AccessSeleccion { get; set; } 
        public string NombreCandidato { get; set; }
    }
}
