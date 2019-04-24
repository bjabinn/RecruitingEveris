using EverNext.Domain.Model.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("CorreoPlantillaVariable")]
    public class CorreoPlantillaVariable : ModifiableEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("VariableId")]
        public int AdjuntoId { get; set; }
        
        [Column("PlantillaId")]
        [Required]
        [ForeignKey("Plantilla")]
        public int PlantillaId { get; set; }
        
        [Column("NombreVariable")]
        [MaxLength]
        public string NombreVariable { get; set; }

        [Column("ValorDefecto")]
        [MaxLength]
        public string ValorDefecto { get; set; }


        #endregion

        #region Navigation Properties

        [NavigationProperty]
        public virtual CorreoPlantilla Plantilla { get; set; }

        [NavigationProperty]
        public virtual ICollection<CorreoPlantillaVariableValor> CorreoPlantillaVariableValores { get; set; }
        #endregion
    }
}
