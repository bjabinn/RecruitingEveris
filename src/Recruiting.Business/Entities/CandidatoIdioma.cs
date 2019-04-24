using EverNext.Domain.Model.Attributes;
using Recruiting.Infra.RepositoryBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("CandidatoIdioma")]
    public class CandidatoIdioma : BaseEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("CandidatoIdiomasId")]
        public int CandidatoIdiomasId { get; set; }

        [Column("CandidatoId")]
        [Required]
        [ForeignKey("Candidato")]
        public int CandidatoId { get; set; }

        [Column("IdiomaId")]
        [Required]
        [ForeignKey("Idioma")]
        public int IdiomaId { get; set; }

        [Column("NivelIdiomaId")]
        [Required]
        [ForeignKey("NivelIdioma")]
        public int NivelIdiomaId { get; set; }

        #endregion

        #region Navigation Properties

        [NavigationProperty]
        public virtual Candidato Candidato { get; set; }

        [NavigationProperty]
        public virtual Maestro Idioma { get; set; }

        [NavigationProperty]
        public virtual Maestro NivelIdioma { get; set; }

        #endregion
    }
}
