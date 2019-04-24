using EverNext.Domain.Model.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("CorreoPlantilla")]
    public class CorreoPlantilla : ModifiableEntity
    {
        #region Scalar Properties

       [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("PlantillaId")]
        public int PlantillaId { get; set; }

        [Column("NombrePlantilla")]
        public string NombrePlantilla { get; set; }

        [Column("TextoPlantilla")]
        [MaxLength]
        public string TextoPlantilla { get; set; }

        [Column("Centro")]
        [ForeignKey("Centro")]
        public int? CentroId { get; set; }

        [Column("Oficina")]
        [ForeignKey("Oficina")]
        public int? OficinaId { get; set; }
        #endregion

        #region Navigation Properties

        [NavigationProperty]
        public virtual ICollection<Correo> Correos { get; set; }

        [NavigationProperty]
        public virtual ICollection<CorreoPlantillaVariable> CorreoPlantillaVariables { get; set; }


        [NavigationProperty]
        public virtual ICollection<CorreoPlantillaVariableValor> CorreoPlantillaVariableValores { get; set; }

        [NavigationProperty]
        public virtual Centro Centro { get; set; }

        [NavigationProperty]
        public virtual Oficina Oficina { get; set; }
        #endregion
    }
}
