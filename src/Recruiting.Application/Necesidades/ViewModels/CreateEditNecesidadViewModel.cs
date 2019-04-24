using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.Necesidades.ViewModels
{
    [Serializable]
    public class CreateEditNecesidadViewModel
    {
        //ATENCION!! Si se cambia alguno de los nombres de estas propiedades afectará directamnete
        // al javascript de la vista de SeguimientoGrupoNecesidad. Se recomienda no realizar ningún
        // cambio de nombres.
        
        //Required
        public int? NecesidadId { get; set; }
        
        //Required, Max(100)
        public string Nombre { get; set; }
        
        //Required
        public int OficinaId { get; set; }

        public string OficinaNombre { get; set; }        

        //Required
        public int CentroId { get; set; }
        
        //Required
        public int SectorId { get; set; }

        public string SectorNombre { get; set; }

        //Required
        public int ClienteId { get; set; }

        public string ClienteNombre { get; set; }

        //Required
        public int ProyectoId { get; set; }

        public string ProyectoNombre { get; set; }

        //Required
        public int TipoServicioId { get; set; }

        public string TipoServicioNombre { get; set; }

        //Required
        public int TipoPerfilId { get; set; }

        public string TipoPerfilNombre { get; set; }

        //Required
        public int TipoTecnologiaId { get; set; }

        public string TipoTecnologiaNombre { get; set; }

        //Required
        public int TipoContratacionId { get; set; }

        public string TipoContratacionNombre { get; set; }

        //Required
        public int TipoPrevisionId { get; set; }

        public string TipoPrevisionNombre { get; set; }

        //Required
        public int MesesAsignacionId { get; set; }

        public string MesesAsignacionNombre { get; set; }

        public string DetalleTecnologia { get; set; }


        public bool DisponibilidadViajes { get; set; }

        public bool DisponibilidadReubicacion { get; set; }
        
        //Required
        public DateTime? FechaSolicitud { get; set; }

        public DateTime? FechaCompromiso { get; set; }

        public DateTime? FechaCierre { get; set; }

        public int EstadoNecesidadId { get; set; }

        public string EstadoNecesidadNombre { get; set; }

        public string NombreCentro { get; set; }

        public string PersonaAsignada { get; set; }

        public string Modulo { get; set; }

        public string NombreModulo { get; set; }

        public bool NecesidadIdioma { get; set; }

        public int? PersonaAsignadaId { get; set; } //no está en la BD pero me hace falta para salvar en edición. Será Id de persona Libre si es cambio interno e IdCandidato si es contratación

        public int? PersonaAsignadaNroEmpleado { get; set; } //lo necesito para actualizar la persona libre en caso de que haya sido agregada previamente de nuevo antes de cambiar la necesidad. Null en caso de contratacion.

        public int? candidaturaId { get; set; }

        public bool? AsignadaCorrectamente { get; set; }

        public int? GrupoNecesidad { get; set; }

        public string GrupoNecesidadName { get; set; }

        public string ReferenciaExterna { get; set; }

        public bool Activo { get; set; }

        public IEnumerable<SelectListItem> PerfilList { get; set; }
        public IEnumerable<SelectListItem> OficinaList { get; set; }
        public IEnumerable<SelectListItem> PrevisionList { get; set; }
        public IEnumerable<SelectListItem> TecnologiaList { get; set; }
        public IEnumerable<SelectListItem> EstadoList { get; set; }
        public IEnumerable<SelectListItem> ContratacionList { get; set; }
        public IEnumerable<SelectListItem> CentroList { get; set; }
        public IEnumerable<SelectListItem> ClienteList { get; set; }
        public IEnumerable<SelectListItem> ProyectoList { get; set; }
        public IEnumerable<SelectListItem> SectorList { get; set; }
        public IEnumerable<SelectListItem> CategoriaList { get; set; }
        public IEnumerable<SelectListItem> ServicioList { get; set; }
        public IEnumerable<SelectListItem> ModuloList { get; set; }
        public IEnumerable<SelectListItem> MesesAsignacionList { get; set; }
        public string CentroIdUsuarioLogueado { get; set; }

    }
}
