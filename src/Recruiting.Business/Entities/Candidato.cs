using EverNext.Domain.Model.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("Candidato")]
    public class Candidato : ModifiableEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("CandidatoId")]
        public int CandidatoId { get; set; }

        [Column("Nombre")]
        [Required]
        [StringLength(500)]
        public string Nombre { get; set; }

        [Column("Apellidos")]
        [Required]
        [StringLength(500)]
        public string Apellidos { get; set; }

        [Column("FechaNacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [Column("TipoIdentificacionId")]
        [ForeignKey("TipoIdentificacion")]
        public int? TipoIdentificacionId { get; set; }

        [Column("NumeroIdentificacion")]
        [StringLength(10)]
        public string NumeroIdentificacion { get; set; }

        //[Column("SalarioDeseado")]
        //public decimal? SalarioDeseado { get; set; }

        [Column("DisponibilidadViaje")]
        [Required]
        public bool DisponibilidadViaje { get; set; }

        [Column("CambioResidencia")]
        [Required]
        public bool CambioResidencia { get; set; }

        [Column("TitulacionId")]
        [Required]
        [ForeignKey("Titulacion")]
        public int TitulacionId { get; set; }

        [Column("DetalleTitulacion")]
        [StringLength(500)]
        public string DetalleTitulacion { get; set; }

        [Column("EstadoCandidatoId")]
        [Required]
        [ForeignKey("EstadoCandidato")]
        public int EstadoCandidatoId { get; set; }

        [Column("Direccion")]
        public string Direccion { get; set; }

        [Column("AnioRegresado")]
        public string AnioRegresado { get; set; }

        [Column("CandidatoCentroEducativoId")]
        [ForeignKey("CandidatoCentroEducativo")]
        public int? CandidatoCentroEducativoId { get; set; }

        #endregion

        #region Navigation Properties

        [NavigationProperty]
        public virtual Maestro TipoIdentificacion { get; set; }
        
        [NavigationProperty]
        public virtual Maestro Titulacion { get; set; }
        
        [NavigationProperty]
        public virtual Maestro EstadoCandidato { get; set; }

        [NavigationProperty]
        public virtual ICollection<CandidatoContacto> CandidatoContactos { get; set; }

        [NavigationProperty]
        public virtual ICollection<CandidatoExperiencia> CandidatoExperiencias { get; set; }

        [NavigationProperty]
        public virtual ICollection<CandidatoIdioma> CandidatoIdiomas { get; set; }


        [NavigationProperty]
        public virtual ICollection<Candidatura> Candidaturas { get; set; }

        [NavigationProperty]
        public virtual CandidatoCentroEducativo CandidatoCentroEducativo { get; set; }
        #endregion
    }
}
