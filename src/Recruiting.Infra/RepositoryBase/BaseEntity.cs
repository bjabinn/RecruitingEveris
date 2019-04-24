using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Infra.RepositoryBase
{
    public class BaseEntity
    {
        #region Scalar Properties

        [Column("Activo")]
        [Required]
        public bool IsActivo { get; set; }

        #endregion
    }
}
