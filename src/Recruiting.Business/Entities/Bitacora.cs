using EverNext.Domain.Model.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("Bitacora")]
    public class Bitacora : ModifiableEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("BitacoraId")]
        public int BitacoraId { get; set; }

        [Column("CandidaturaId")]
        [Required]
        public int CandidaturaId { get; set; }

        [Column("TipoBitacora")]
        public int? TipoBitacora { get; set; }

        [Column("MensajeSistema")]
        [MaxLength]
        public string MensajeSistema { get; set; }

        [Column("Observaciones")]
        [MaxLength]
        public string Observaciones { get; set; }

        [Column("EstadoAnteriorId")]
        [ForeignKey("EstadoAnterior")]
        public int? EstadoAnteriorId { get; set; }

        [Column("EstadoNuevoId")]
        [ForeignKey("EstadoNuevo")]
        public int? EstadoNuevoId { get; set; }

        [Column("EtapaAnteriorId")]
        [ForeignKey("EtapaAnterior")]
        public int? EtapaAnteriorId { get; set; }

        [Column("EtapaNuevaId")]
        [ForeignKey("EtapaNueva")]
        public int? EtapaNuevaId { get; set; }

        [Column("Revertible")]
        public bool? Revertible { get; set; }
        #endregion

        #region Navigation Properties
        [NavigationProperty]
        public virtual Candidatura Candidatura { get; set; }

        [NavigationProperty]
        public virtual TipoEstadoCandidatura EstadoAnterior { get; set; }

        [NavigationProperty]
        public virtual TipoEstadoCandidatura EstadoNuevo { get; set; }

        [NavigationProperty]
        public virtual TipoEtapaCandidatura EtapaAnterior { get; set; }

        [NavigationProperty]
        public virtual TipoEtapaCandidatura EtapaNueva { get; set; }
        #endregion
    }
}
