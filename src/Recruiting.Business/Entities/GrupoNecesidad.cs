using EverNext.Domain.Model.Attributes;
using Recruiting.Infra.RepositoryBase;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("GrupoNecesidad")]
    public class GrupoNecesidad : ModifiableEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("GrupoNecesidadId")]
        public int GrupoNecesidadId { get; set; }       

        [Column("Nombre")]
        [StringLength(250)]
        public string Nombre { get; set; }

        [Column("Descripcion")]
        [MaxLength]
        public string Descripcion { get; set; }

        [Column("GrupoCerrado")]
        [Required]
        public bool GrupoCerrado { get; set; }

        #endregion

        #region Navigation Properties

        [NavigationProperty]
        public virtual ICollection<Necesidad> NecesidadesAsignadas { get; set; }

        #endregion
    }
}
