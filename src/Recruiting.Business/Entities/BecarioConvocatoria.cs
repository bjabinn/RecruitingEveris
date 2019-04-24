using Recruiting.Infra.RepositoryBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("BecarioConvocatoria")]
    public class BecarioConvocatoria : BaseEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("BecarioConvocatoriaId")]
        public int BecarioConvocatoriaId { get; set; }

        [Column("NombreConvocatoria")]
        [MaxLength]
        public string NombreConvocatoria { get; set; }

        [Column("CentroId")]
        [ForeignKey("Centro")]       
        public int? CentroId { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Centro Centro { get; set; }

        #endregion

    }
}
