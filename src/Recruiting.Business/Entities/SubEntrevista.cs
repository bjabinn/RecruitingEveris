using EverNext.Domain.Model.Attributes;
using Recruiting.Infra.RepositoryBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("SubEntrevista")]
    public class SubEntrevista : BaseEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("SubEntrevistaId")]
        public int SubEntrevistaId { get; set; }

        [Column("EntrevistadorId")]
        [Required]
        [ForeignKey("Entrevistador")]
        public int? EntrevistadorId { get; set; }
                
        [Column("FechaEntrevista")]
        [Required]
        public DateTime FechaEntrevista { get; set; }       
        
        [Column("Completada")]
        [Required]
        public bool Completada { get; set; }
                
        [Column("EntrevistaId")]
        [Required]
        [ForeignKey("Entrevista")]
        public int EntrevistaId { get; set; }
                
        [Column("Observaciones")]
        [MaxLength]
        public string Observaciones { get; set; }

        [Column("TipoSubEntrevistaId")]
        [Required]
        [ForeignKey("TipoSubEntrevista")]
        public int? TipoSubEntrevistaId { get; set; }

        [Column("SalarioPropuesto")]
        public decimal? SalarioPropuesto { get; set; }

        [Column("SalarioDeseado")]
        public decimal? SalarioDeseado { get; set; }

        [Column("SalarioActual")]
        public decimal? SalarioActual { get; set; }

        [Column("IncorporacionId")]
        [ForeignKey("Incorporacion")]
        public int? IncorporacionId { get; set; }

        [Column("DisponibilidadViajes")]
        [Required]
        public bool DisponibilidadViajes { get; set; }

        [Column("CambioResidencia")]
        [Required]
        public bool CambioResidencia { get; set; }

        [Column("CategoriaId")]
        [ForeignKey("Categoria")]
        public int? CategoriaId { get; set; }

        [Column("Presencial")]
        [Required]
        public bool Presencial { get; set; }

        [Column("SuperaEntrevista")]
        [Required]
        public bool SuperaSubEntrevista { get; set; }

        [Column("AvisarAlCandidato")]
        [Required]
        public bool AvisarAlCandidato { get; set; }

        #endregion

        #region Navigation Properties

        [NavigationProperty]
        public virtual Usuario Entrevistador { get; set; }

        [NavigationProperty]
        public virtual Entrevista Entrevista { get; set; }

        [NavigationProperty]
        public virtual Maestro TipoSubEntrevista { get; set; }

        [NavigationProperty]
        public virtual Maestro Incorporacion { get; set; }

        [NavigationProperty]
        public virtual Maestro Categoria { get; set; }

        #endregion
    }
}
