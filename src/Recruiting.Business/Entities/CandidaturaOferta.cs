using Recruiting.Infra.RepositoryBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("CandidaturaOferta")]
    public class CandidaturaOferta : BaseEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("CandidaturaOfertaId")]
        public int CandidaturaOfertaId { get; set; }

        [Column("NombreOferta")]
        [MaxLength]
        public string NombreOferta { get; set; }

        [Column("CentroId")]
        [ForeignKey("Centro")]       
        public int? CentroId { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Centro Centro { get; set; }

        #endregion

    }
}
