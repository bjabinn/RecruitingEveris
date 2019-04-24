using EverNext.Domain.Model.Attributes;
using Recruiting.Infra.RepositoryBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("TipoDecision")]
    public class TipoDecision : BaseEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("TipoDecisionId")]
        public int TipoDecisionId { get; set; }

        [Column("Decision")]
        [Required]
        [StringLength(250)]
        public string Decision { get; set; }

        [Column("TipoEtapaCandidaturaId")]
        [Required]
        [ForeignKey("TipoEtapaCandidatura")]
        public int TipoEtapaCandidaturaId { get; set; }
        
        #endregion

        #region Navigation Properties

        [NavigationProperty]
        public virtual TipoEtapaCandidatura TipoEtapaCandidatura { get; set; }

        #endregion
    }
}
