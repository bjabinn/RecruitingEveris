using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.Necesidades.ViewModels
{
    [Serializable]
    public class CreateEditGrupoNecesidadViewModel
    {        
        public int? GrupoNecesidadId { get; set; }  
        public string NombreGrupo { get; set; }
        public string DescripcionGrupo { get; set; }
        public bool EstadoGrupo { get; set; }
        //CAMPOS COMUNES NECESIDADES        
        public int CentroId { get; set; }
        public int OficinaId { get; set; }
        public int SectorId { get; set; }    
        public int ClienteId { get; set; }
        public int ProyectoId { get; set; }
        public int TipoServicioId { get; set; }
        public int MesesAsignacionId { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public string DetalleTecnologia { get; set; }

        public bool DisponibilidadViajes { get; set; }
        public bool DisponibilidadReubicacion { get; set; }
        public bool NecesidadIdioma { get; set; }

        public string NecesidadesBorradas { get; set; }
        public List<int> Multiplicadores { get; set; }
        public IEnumerable<CreateEditNecesidadViewModel> ListaNecesidades { get; set; }

        public bool Activo { get; set; }


        public IEnumerable<SelectListItem> PerfilList { get; set; }
        public IEnumerable<SelectListItem> OficinaList { get; set; }
        public IEnumerable<SelectListItem> PrevisionList { get; set; }
        public IEnumerable<SelectListItem> TecnologiaList { get; set; }
        public IEnumerable<SelectListItem> ContratacionList { get; set; }
        public IEnumerable<SelectListItem> CentroList { get; set; }
        public IEnumerable<SelectListItem> ClienteList { get; set; }
        public IEnumerable<SelectListItem> ProyectoList { get; set; }
        public IEnumerable<SelectListItem> SectorList { get; set; }
        public IEnumerable<SelectListItem> CategoriaList { get; set; }
        public IEnumerable<SelectListItem> ServicioList { get; set; }
        public IEnumerable<SelectListItem> ModuloList { get; set; }
        public IEnumerable<SelectListItem> MesesAsignacionList { get; set; }
        public IEnumerable<SelectListItem> EstadoList { get; set; }
        public IEnumerable<SelectListItem> EstadoStaffingNecesidadList { get; set; }
        public string CentroIdUsuarioLogueado { get; set; }
        public ModalEdicionPerfilViewModel ModalEdicionPerfil { get; set; }
    }
}
