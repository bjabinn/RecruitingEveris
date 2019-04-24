using EverNext.Domain.Model.Attributes;
using Recruiting.Infra.RepositoryBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("CandidatoExperiencia")]
    public class CandidatoExperiencia : BaseEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("CandidatoExperienciaId")]
        public int CandidatoExperienciaId { get; set; }

        [Column("CandidatoId")]
        [Required]
        [ForeignKey("Candidato")]
        public int CandidatoId { get; set; }

        [Column("TipoTecnologiaId")]
        [Required]
        [ForeignKey("TipoTecnologia")]
        public int TipoTecnologiaId { get; set; }

        [Column("NivelTecnologiaId")]
        [Required]
        [ForeignKey("NivelTecnologia")]
        public int NivelTecnologiaId { get; set; }

        [Column("Experiencia")]
        [Required]
        public int Experiencia { get; set; }

        #endregion

        #region Navigation Properties

        [NavigationProperty]
        public virtual Candidato Candidato { get; set; }

        [NavigationProperty]
        public virtual Maestro TipoTecnologia { get; set; }

        [NavigationProperty]
        public virtual Maestro NivelTecnologia { get; set; }

        #endregion
    }
}
