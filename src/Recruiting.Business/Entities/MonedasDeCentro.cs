using EverNext.Domain.Model.Attributes;
using Recruiting.Infra.RepositoryBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("MonedasDeCentro")]
    public class MonedasDeCentro : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("MonedasDeCentroId")]
        public int MonedaDeCentroId { get; set; }

        [Column("Centro")]
        [Required]
        [ForeignKey("Centro")]
        public int CentroId { get; set; }

        [Column("Descripción")]
        [Required]
        [StringLength(3)]
        public string Moneda { get; set; }

        #region Navigation Properties

        [NavigationProperty]
        public virtual Centro Centro { get; set; }

        #endregion
    }
}
