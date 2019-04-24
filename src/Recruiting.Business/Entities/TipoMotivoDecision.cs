using EverNext.Domain.Model.Attributes;
using Recruiting.Infra.RepositoryBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("TipoMotivoDecision")]
    public class TipoMotivoDecision : BaseEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity), Column("TipoMotivoDecisionId")]
        public int TipoMotivoDecisionId { get; set; }

        [Column("MotivoDecision")]
        [Required]
        [MaxLength]
        public string MotivoDecision { get; set; }

        [Column("TipoDecisionId")]
        [Required]
        [ForeignKey("TipoDecision")]
        public int TipoDecisionId { get; set; }

        #endregion

        #region Navigation Properties

        [NavigationProperty]
        public virtual TipoDecision TipoDecision { get; set; }

        #endregion
    }
}
