using Recruiting.Infra.RepositoryBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("TipoEntrevista")]
    public class TipoEntrevista : BaseEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("TipoEntrevistaId")]
        public int TipoEntrevistaId { get; set; }

        [Column("TipoEntrevista")]
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        #endregion

    }
}
