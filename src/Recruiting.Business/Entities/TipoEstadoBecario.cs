using Recruiting.Infra.RepositoryBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("TipoEstadoBecario")]
    public class TipoEstadoBecario : BaseEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("TipoEstadoBecarioId")]
        public int TipoEstadoBecarioId { get; set; }

        [Column("EstadoBecario")]
        [MaxLength]
        public string EstadoBecario { get; set; }

        [Column("Orden")]
        public int? Orden { get; set; }

        #endregion

    }
}

