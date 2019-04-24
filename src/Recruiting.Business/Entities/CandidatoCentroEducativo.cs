using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recruiting.Infra.RepositoryBase;

namespace Recruiting.Business.Entities
{
    [Table("CandidatoCentroEducativo")]
    public class CandidatoCentroEducativo : BaseEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("CandidatoCentroEducativoId")]
        public int CandidatoCentroEducativoId { get; set; }

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
