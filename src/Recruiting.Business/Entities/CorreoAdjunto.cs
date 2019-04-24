using EverNext.Domain.Model.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
   
    [Table("CorreoAdjunto")]
    public class CorreoAdjunto : ModifiableEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("FicheroAdjuntoId")]
        public int FicheroAdjuntoId { get; set; }
        
        
        [Column("CorreoId")]
        [Required]
        [ForeignKey("Correo")]
        public int CorreoId { get; set; }


        [Column("FicheroAdjunto")]
        public byte[] Fichero { get; set; }
        
        [Column("NombreFicheroAdjunto")]
        [MaxLength]
        public string NombreFichero { get; set; }
        
       
        #endregion

        #region Navigation Properties

        [NavigationProperty]
        public virtual Correo Correo { get; set; }
        
        #endregion
    }
}
