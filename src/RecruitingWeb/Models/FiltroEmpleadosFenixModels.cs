using Recruiting.Application.PersonasLibres.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RecruitingWeb.Models
{
    public class FiltroEmpleadosFenixModels
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Categoria { get; set; }
        public string Linea { get; set; }
        public string Celda { get; set; }        
        public string Centro { get; set; }
        public int? NumeroEmpleado { get; set; }
        public int? CentroIdUsuario { get; set; }
        public List<PersonaLibreRowViewModel> PersonaLibreRowViewModelList { get; set; }
        public EmpleadosFenixListCategoriaLineaCeldaviewModel EmpleadosFenixListCategoriaLineaCelda { get; set; }
        public string Buscar { get; set; }


        public IEnumerable<SelectListItem> CentroList { get; set; }
        public string CentroIdUsuarioLogueado { get; set; }
        public int? Pagina { get; set; }


    }
}