using EverNext.Domain.Model.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("CartaOferta")]
    public class CartaOferta : ModifiableEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("CartaOfertaId")]
        public int CartaOfertaId { get; set; }

        [Column("CandidaturaId")]
        [Required]
        [ForeignKey("Candidatura")]
        public int CandidaturaId { get; set; }

        [Column("EntrevistadorId")]
        [Required]
        [ForeignKey("Entrevistador")]
        public int EntrevistadorId { get; set; }
                
        [Column("FechaCartaOferta")]
        [Required]
        public DateTime FechaCartaOferta { get; set; }
        
        [Column("Observaciones")]
        [MaxLength]
        public string Observaciones { get; set; }
        
        [Column("Acepta")]
        public bool? Acepta { get; set; }

        [Column("MotivoRechazoId")]
        [ForeignKey("MotivoRechazo")]
        public int? MotivoRechazoId { get; set; }
                
        [Column("FechaIncorporacion")]
        public DateTime? FechaIncorporacion { get; set; }

        [Column("NecesidadId")]
        [ForeignKey("Necesidad")]
        public int? NecesidadId { get; set; }


        [Column("CartaOfertaGenerada")]
        public byte[] CartaOfertaGenerada { get; set; }

        [Column("Oficina")]
        [ForeignKey("Oficina")]
        public int? OficinaId { get; set; }
        #endregion

        #region Navigation Properties

        [NavigationProperty]
        public virtual Candidatura Candidatura { get; set; }

        [NavigationProperty]
        public virtual Usuario Entrevistador { get; set; }

        [NavigationProperty]
        public virtual Maestro MotivoRechazo { get; set; }

        [NavigationProperty]
        public virtual Necesidad Necesidad { get; set; }

        [NavigationProperty]
        public virtual Oficina Oficina { get; set; }

        #endregion
    }
}
