using EverNext.Domain.Model.Attributes;
using Recruiting.Infra.RepositoryBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("CandidatoContacto")]
    public class CandidatoContacto : BaseEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("CandidatoContactoId")]
        public int CandidatoContactoId { get; set; }

        [Column("CandidatoId")]
        [Required]
        [ForeignKey("Candidato")]
        public int CandidatoId { get; set; }

        [Column("TipoMedioContactoId")]
        [Required]
        [ForeignKey("TipoMedioContacto")]
        public int TipoMedioContactoId { get; set; }
        
        [Column("Contacto")]
        [Required]
        [StringLength(500)]
        public string Contacto { get; set; }

        #endregion

        #region Navigation Properties

        [NavigationProperty]
        public virtual Candidato Candidato { get; set; }

        [NavigationProperty]
        public virtual Maestro TipoMedioContacto { get; set; }

        #endregion
    }
}
