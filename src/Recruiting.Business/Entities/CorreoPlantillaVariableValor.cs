using EverNext.Domain.Model.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("CorreoPlantillaVariableValor")]
    public class CorreoPlantillaVariableValor : ModifiableEntity
    {
        #region Scalar Properties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("ValorVariableId")]
        public int ValorVariableId { get; set; }

        [Column("CorreoId")]
        [Required]
        [ForeignKey("Correo")]
        public int CorreoId { get; set; }


     
        [Required]
        [Column("PlantillaId")]
        [ForeignKey("CorreoPlantilla")]
        public int PlantillaId { get; set; }


        [Column("VariableId")]
        [Required]
        [ForeignKey("CorreoPlantillaVariable")]
        public int VariableId { get; set; }

        
        [Column("ValorVariable")]
        [Required]
        [MaxLength]
        public string ValorVariable { get; set; }

        #endregion

        #region Navigation Properties
        [NavigationProperty]
        public virtual Correo Correo { get; set; }

        [NavigationProperty]
        public virtual CorreoPlantilla CorreoPlantilla { get; set; }


        [NavigationProperty]
        public virtual CorreoPlantillaVariable CorreoPlantillaVariable { get; set; }


        #endregion
    }
}
