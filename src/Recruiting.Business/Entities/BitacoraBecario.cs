using EverNext.Domain.Model.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("BitacoraBecario")]
    public class BitacoraBecario : ModifiableEntity
    {
        #region Scalar Properties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("BitacoraId")]
        public int BitacoraId { get; set; }

        [Column("BecarioId")]
        [Required]
        public int BecarioId { get; set; }

        [Column("TipoBitacora")]
        public int? TipoBitacora { get; set; }

        [Column("MensajeSistema")]
        [MaxLength]
        public string MensajeSistema { get; set; }

        [Column("EstadoAnteriorId")]
        [ForeignKey("EstadoAnterior")]
        public int? EstadoAnteriorId { get; set; }

        [Column("EstadoNuevoId")]
        [ForeignKey("EstadoNuevo")]
        public int? EstadoNuevoId { get; set; }

        [Column("Revertible")]
        public bool? Revertible { get; set; }
        #endregion

        #region Navigation Properties
        [NavigationProperty]
        public virtual Becario Becario { get; set; }

        [NavigationProperty]
        public virtual Maestro EstadoAnterior { get; set; }

        [NavigationProperty]
        public virtual Maestro EstadoNuevo { get; set; }

        #endregion
    }
}
