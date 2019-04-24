using EverNext.Domain.Model.Attributes;
using Recruiting.Infra.RepositoryBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("AdministradorDashboard")]
    public class AdministradorDashboard : BaseEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("AdministradorDashboardId")]
        public int AdministradorDashboardId { get; set; }

        [Column("UsuarioId")]
        [Required]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [Column("NecesidadesCreadasModificadas")]
        public bool NecesidadesCreadasModificadas { get; set; }

        [Column("PrimeraEntrevista")]
        public bool PrimeraEntrevista { get; set; }

        [Column("SubEntrevistaPrimeraEntrevista")]
        public bool SubEntrevistaPrimeraEntrevista { get; set; }

        [Column("SegundaEntrevista")]
        public bool SegundaEntrevista { get; set; }

        [Column("SubEntrevistaSegundaEntrevista")]
        public bool SubEntrevistaSegundaEntrevista { get; set; }

        [Column("CartaOferta")]
        public bool CartaOferta { get; set; }

        [Column("CvPendienteFiltro")]
        public bool CvPendienteFiltro { get; set; }

        [Column("CandidaturaStandBy")]
        public bool CandidaturaStandBy { get; set; }

        [Column("BecarioStandBy")]
        public bool BecarioStandBy { get; set; }



        #endregion

        #region Navigation Properties

        [NavigationProperty]
        public virtual Usuario Usuario { get; set; }


        #endregion
    }
}
