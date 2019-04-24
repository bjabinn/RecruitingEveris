using EverNext.Domain.Model.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("CorreoBecario")]
    public class CorreoBecario : ModifiableEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("CorreoBecarioId")]
        public int CorreoBecarioId { get; set; }

        [Required]
        [Column("PlantillaId")]
        [ForeignKey("CorreoPlantilla")]
        public int PlantillaId { get; set; }
        
        [Column("BecarioId")]
        [ForeignKey("Becario")]
        public int? BecarioId { get; set; }

        [Column("Asunto")]
        [MaxLength]
        public string Asunto { get; set; }
        
        [Column("Destinatarios")]
        [MaxLength]
        public string Destinatarios { get; set; }

        [Column("Remitente")]
        [MaxLength]
        public string Remitente { get; set; }

        [Required]
        [Column("Enviado")]
        public bool Enviado { get; set; }

        [Column("FechaEnvio")]
        public DateTime? FechaEnvio { get; set; }

        [Column("TipoAviso")]
        [MaxLength]
        public string TipoAviso { get; set; }

        #endregion

        #region Navigation Properties

        [NavigationProperty]
        public virtual CorreoPlantilla CorreoPlantilla { get; set; }

        [NavigationProperty]
        public virtual Becario Becario { get; set; }

        [NavigationProperty]
        public virtual ICollection<CorreoPlantillaVariableValor> CorreoPlantillaVariableValores { get; set; }

        [NavigationProperty]
        public virtual ICollection<CorreoAdjunto> CorreoAdjuntos { get; set; }
        #endregion
    }
}
