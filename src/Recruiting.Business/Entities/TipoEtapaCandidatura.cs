using Recruiting.Infra.RepositoryBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("TipoEtapaCandidatura")]
    public class TipoEtapaCandidatura : BaseEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity), Column("TipoEtapaCandidaturaId")]
        public int TipoEtapaCandidaturaId { get; set; }

        [Column("EtapaCandidatura")]
        [MaxLength]
        public string EtapaCandidatura { get; set; }

        [Column("Orden")]
        public int? Orden { get; set; }
        #endregion

    }
}
