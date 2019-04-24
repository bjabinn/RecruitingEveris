using EverNext.Domain.Model.Attributes;
using Recruiting.Infra.RepositoryBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("RelacionEtapa")]
    public class RelacionEtapa : BaseEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity), Column("RelacionEtapaId")]
        public int RelacionEtapaId { get; set; }

        [Column("EtapaOrigenId")]
        [Required]
        [ForeignKey("EtapaOrigen")]
        public int EtapaOrigenId { get; set; }

        [Column("EtapaFinId")]
        [ForeignKey("EtapaFin")]
        public int? EtapaFinId { get; set; }

        [Column("TipoDecisionId")]
        [ForeignKey("TipoDecision")]
        public int? TipoDecisionId { get; set; }

        [Column("EstadoOrigenId")]
        [ForeignKey("EstadoOrigen")]
        public int? EstadoOrigenId { get; set; }

        [Column("EstadoFinId")]
        [ForeignKey("EstadoFin")]
        public int? EstadoFinId { get; set; }
       
        #endregion

        #region Navigation Properties

        [NavigationProperty]
        public virtual TipoEtapaCandidatura EtapaOrigen { get; set; }

        [NavigationProperty]
        public virtual TipoEtapaCandidatura EtapaFin { get; set; }

        [NavigationProperty]
        public virtual TipoDecision TipoDecision { get; set; }

        [NavigationProperty]
        public virtual TipoEstadoCandidatura EstadoOrigen { get; set; }

        [NavigationProperty]
        public virtual TipoEstadoCandidatura EstadoFin { get; set; }

        #endregion
    }
}
