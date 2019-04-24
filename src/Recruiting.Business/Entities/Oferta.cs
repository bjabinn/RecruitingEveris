using EverNext.Domain.Model.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("Oferta")]
    public class Oferta : ModifiableEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity), Column("OfertaId")]
        public int OfertaId { get; set; }

        [Column("Nombre")]
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        
        [Column("EstadoOfertaId")]
        [Required]
        [ForeignKey("EstadoOferta")]
        public int EstadoOfertaId { get; set; }
                
        [Column("FechaPublicacion")]
        public DateTime? FechaPublicacion { get; set; }
        
        [Column("Descripcion")]
        [StringLength(4000)]
        public string Descripcion { get; set; }

        #endregion

        #region Navigation Properties

        [NavigationProperty]
        public virtual Maestro EstadoOferta { get; set; }

        [NavigationProperty]
        public virtual ICollection<Candidatura> Candidaturas { get; set; }

        #endregion
    }
}
