using EverNext.Domain.Model.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("Entrevista")]
    public class Entrevista : ModifiableEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("EntrevistaId")]
        public int EntrevistaId { get; set; }

        [Column("EntrevistadorId")]
        [Required]
        [ForeignKey("Entrevistador")]
        public int? EntrevistadorId { get; set; }
                
        [Column("FechaEntrevista")]
        [Required]
        public DateTime FechaEntrevista { get; set; }
        
        [Column("Presencial")]
        [Required]
        public bool Presencial { get; set; }
        
        [Column("SuperaEntrevista")]
        [Required]
        public bool SuperaEntrevista { get; set; }

        [Column("SinDecision")]
        [Required]
        public bool SinDecision { get; set; } = true;

        [Column("MotivoId")]
        [ForeignKey("Motivo")]
        public int? MotivoId { get; set; }
                
        [Column("ResultadoTest")]
        public int? ResultadoTest { get; set; }

        [Column("TipoEntrevistaId")]
        [Required]
        [ForeignKey("TipoEntrevista")]
        public int TipoEntrevistaId { get; set; }
                
        [Column("Observaciones")]
        [MaxLength]
        public string Observaciones { get; set; }

        [Column("CandidaturaId")]
        [Required]
        [ForeignKey("Candidatura")]
        public int CandidaturaId { get; set; }

        [Column("TS")]
        public byte[] TS { get; set; }

        [Column("NombreTS")]
        [MaxLength]
        public string NombreTS { get; set; }

        [Column("AvisarAlCandidato")]
        [Required]
        public bool AvisarAlCandidato { get; set; }

        //[Column("Completada")]
        //[Required]
        //public bool Completada { get; set; }

        [Column("Oficina")]
        [ForeignKey("Oficina")]
        public int? OficinaId { get; set; }

        #endregion

        #region Navigation Properties

        [NavigationProperty]
        public virtual Usuario Entrevistador { get; set; }

        [NavigationProperty]
        public virtual Maestro Motivo { get; set; }

        [NavigationProperty]
        public virtual TipoEntrevista TipoEntrevista { get; set; }

        [NavigationProperty]
        public virtual Candidatura Candidatura { get; set; }

        [NavigationProperty]
        public virtual ICollection<SubEntrevista> SubEntrevista { get; set; }

        [NavigationProperty]
        public virtual Oficina Oficina { get; set; }
        #endregion
    }
}
