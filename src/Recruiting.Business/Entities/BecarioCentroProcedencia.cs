using Recruiting.Infra.RepositoryBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("BecarioCentroProcedencia")]
    public class BecarioCentroProcedencia : BaseEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("BecarioCentroProcedenciaId")]
        public int BecarioCentroProcedenciaId { get; set; }

        [Column("Centro")]
        [MaxLength]
        public string Centro { get; set; }

        [Column("Ciudad")]
        [MaxLength]
        public string Ciudad { get; set; }

        [Column("Pais")]
        [MaxLength]
        public string Pais { get; set; }
        
        #endregion

    }
}
