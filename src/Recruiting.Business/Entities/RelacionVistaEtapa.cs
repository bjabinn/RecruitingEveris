using EverNext.Domain.Model.Attributes;
using Recruiting.Infra.RepositoryBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("RelacionVistaEtapa")]
    public class RelacionVistaEtapa : BaseEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("RelacionVistaEtapaId")]
        public int RelacionVistaEtapaId { get; set; }

        [Column("EtapaId")]
        [Required]
        [ForeignKey("Etapa")]
        public int EtapaId { get; set; }
        
        [Column("VistaMostrar")]
        [MaxLength]
        public string VistaMostrar { get; set; }

        [Column("EstadoId")]
        [Required]
        [ForeignKey("Estado")]
        public int EstadoId { get; set; }

        #endregion

        #region Navigation Properties

        [NavigationProperty]
        public virtual TipoEtapaCandidatura Etapa { get; set; }

        [NavigationProperty]
        public virtual TipoEstadoCandidatura Estado { get; set; }

        #endregion
    }
}
