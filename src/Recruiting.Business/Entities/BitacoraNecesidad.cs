using EverNext.Domain.Model.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("BitacoraNecesidad")]
    public class BitacoraNecesidad : ModifiableEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("BitacoraId")]
        public int BitacoraId { get; set; }

        [Column("NecesidadId")]
        [Required]
        public int NecesidadId { get; set; }

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

        [Column("PerfilAnteriorId")]
        [ForeignKey("PerfilAnterior")]
        public int? PerfilAnteriorId { get; set; }

        [Column("PerfilNuevoId")]
        [ForeignKey("PerfilNuevo")]
        public int? PerfilNuevoId { get; set; }

        [Column("FechaSolicitudAnterior")]
        public DateTime? FechaSolicitudAnterior { get; set; }

        [Column("FechaSolicitudNueva")]
        public DateTime? FechaSolicitudNueva { get; set; }

        [Column("FechaCompromisoAnterior")]
        public DateTime? FechaCompromisoAnterior { get; set; }

        [Column("FechaCompromisoNueva")]
        public DateTime? FechaCompromisoNueva { get; set; }

        [Column("FechaCierreAnterior")]
        public DateTime? FechaCierreAnterior { get; set; }

        [Column("FechaCierreNueva")]
        public DateTime? FechaCierreNueva { get; set; }

        [Column("PersonaAsignadaAnterior")]
        public string PersonaAsignadaAnterior { get; set; }

        [Column("PersonaAsignadaNueva")]
        public string PersonaAsignadaNueva { get; set; }



        #endregion

        #region Navigation Properties
        [NavigationProperty]
        public virtual Necesidad Necesidad { get; set; }

        [NavigationProperty]
        public virtual Maestro EstadoAnterior { get; set; }

        [NavigationProperty]
        public virtual Maestro EstadoNuevo { get; set; }

        [NavigationProperty]
        public virtual Maestro PerfilAnterior { get; set; }

        [NavigationProperty]
        public virtual Maestro PerfilNuevo { get; set; }      


        #endregion
    }
}
