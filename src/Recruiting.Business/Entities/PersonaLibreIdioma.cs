using EverNext.Domain.Model.Attributes;
using Recruiting.Infra.RepositoryBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("PersonaLibreIdioma")]
    public class PersonaLibreIdioma : BaseEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("PersonaLibreIdiomasId")]
        public int PersonaLibreIdiomasId { get; set; }

        [Column("PersonaLibreId")]
        [Required]
        [ForeignKey("PersonaLibre")]
        public int PersonaLibreId { get; set; }

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
        public virtual PersonaLibre PersonaLibre { get; set; }

        [NavigationProperty]
        public virtual Maestro Idioma { get; set; }

        [NavigationProperty]
        public virtual Maestro NivelIdioma { get; set; }

        #endregion
    }
}
