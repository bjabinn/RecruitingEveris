using Recruiting.Infra.RepositoryBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("TipoEstadoCandidatura")]
    public class TipoEstadoCandidatura : BaseEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("TipoEstadoCandidaturaId")]
        public int TipoEstadoCandidaturaId { get; set; }

        [Column("EstadoCandidatura")]
        [MaxLength]
        public string EstadoCandidatura { get; set; }

        [Column("Orden")]
        public int? Orden { get; set; }
        #endregion

    }
}
