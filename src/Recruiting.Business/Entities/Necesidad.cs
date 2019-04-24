using EverNext.Domain.Model.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("Necesidad")]
    public class Necesidad : ModifiableEntity
    {
        #region Constructor
        public Necesidad()
        {
            this.CartasOferta = new HashSet<CartaOferta>();
        }
        #endregion

        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("NecesidadId")]
        public int NecesidadId { get; set; }

        [Column("Nombre")]
        [StringLength(250)]
        public string Nombre { get; set; }

        [Column("OficinaId")]
        [Required]
        [ForeignKey("Oficina")]
        public int OficinaId { get; set; }

        [Column("CentroId")]
        [Required]
        [ForeignKey("Centro")]
        public int CentroId { get; set; }

        [Column("SectorId")]
        [Required]
        [ForeignKey("Sector")]
        public int SectorId { get; set; }

        [Column("ProyectoId")]
        [Required]
        [ForeignKey("Proyecto")]
        public int ProyectoId { get; set; }

        [Column("TipoServicioId")]
        [Required]
        [ForeignKey("TipoServicio")]
        public int TipoServicioId { get; set; }

        [Column("TipoPerfilId")]
        [Required]
        [ForeignKey("TipoPerfil")]
        public int TipoPerfilId { get; set; }

        [Column("TipoTecnologiaId")]
        [Required]
        [ForeignKey("TipoTecnologia")]
        public int TipoTecnologiaId { get; set; }

        [Column("TipoContratacionId")]
        [Required]
        [ForeignKey("TipoContratacion")]
        public int TipoContratacionId { get; set; }


        [Column("DisponibilidadViaje")]
        public bool? DisponibilidadViaje { get; set; }

        [Column("NecesidadIdioma")]
        public bool? NecesidadIdioma { get; set; }

        [Column("CambioResidencia")]
        public bool? CambioResidencia { get; set; }

        [Column("TipoPrevisionId")]
        [Required]
        [ForeignKey("TipoPrevision")]
        public int TipoPrevisionId { get; set; }

        [Column("MesesAsignacionId")]
        [Required]
        [ForeignKey("MesesAsignacion")]
        public int MesesAsignacionId { get; set; }

        [Column("EstadoNecesidadId")]
        [Required]
        [ForeignKey("EstadoNecesidad")]
        public int EstadoNecesidadId { get; set; }

        [Column("Observaciones")]
        [MaxLength]
        public string Observaciones { get; set; }

        [Column("FechaSolicitud")]
        [Required]
        public DateTime FechaSolicitud { get; set; }

        [Column("FechaCompromiso")]
        public DateTime? FechaCompromiso { get; set; }

        [Column("FechaCierre")]
        public DateTime? FechaCierre { get; set; }

        [Column("PersonaAsignada")]
        [MaxLength]
        public string PersonaAsignada { get; set; }

        [Column("PersonaAsignadaId")]
        public int? PersonaAsignadaId { get; set; }

        [Column("PersonaAsignadaNroEmpleado")]
        public int? PersonaAsignadaNroEmpleado { get; set; }

        [Column("CandidaturaId")]
        [ForeignKey("Candidatura")]
        public int? CandidaturaId { get; set; }

        [Column("Modulo")]
        public string Modulo { get; set; }

        [Column("AsignadaCorrectamente")]
        public bool? AsignadaCorrectamente { get; set; }

        [Column("GrupoNecesidadId")]
        [ForeignKey("GrupoNecesidad")]
        public int? GrupoNecesidadId { get; set; }

        [Column("PersonaProyecto")]
        public string PersonaProyecto { get; set; }

        [Column("CuentaProyecto")]
        public string CuentaProyecto { get; set; }

        [Column("Prioridad")]
        public int? Prioridad { get; set; }

        [Column("ObservacionesStaffing")]
        public string ObservacionesStaffing { get; set; }

        [Column("ReferenciaExterna")]
        [StringLength(250)]
        public string ReferenciaExterna { get; set; }

        #endregion

        #region Navigation Properties

        [NavigationProperty]
        public virtual Maestro Oficina { get; set; }

        [NavigationProperty]
        public virtual Centro Centro { get; set; }

        [NavigationProperty]
        public virtual Maestro Sector { get; set; }

        [NavigationProperty]
        public virtual Proyecto Proyecto { get; set; }

        [NavigationProperty]
        public virtual Maestro TipoServicio { get; set; }

        [NavigationProperty]
        public virtual Maestro TipoPerfil { get; set; }

        [NavigationProperty]
        public virtual Maestro TipoTecnologia { get; set; }

        [NavigationProperty]
        public virtual Maestro TipoContratacion { get; set; }

        [NavigationProperty]
        public virtual Maestro TipoPrevision { get; set; }

        [NavigationProperty]
        public virtual Maestro MesesAsignacion { get; set; }

        [NavigationProperty]
        public virtual Maestro EstadoNecesidad { get; set; }

        [NavigationProperty]
        public virtual ICollection<CartaOferta> CartasOferta { get; set; }

        [NavigationProperty]
        public virtual Candidatura Candidatura { get; set; }

        //[NavigationProperty]
        //public virtual Maestro TipoModulo { get; set; }

        [NavigationProperty]
        public virtual GrupoNecesidad GrupoNecesidad { get; set; }
    
        #endregion
    }
}
