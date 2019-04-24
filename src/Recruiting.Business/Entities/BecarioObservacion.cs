using EverNext.Domain.Model.Attributes;
using Recruiting.Infra.RepositoryBase;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("BecarioObservacion")]
    public class BecarioObservacion : ModifiableEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("BecarioObservacionId")]
        public int BecarioObservacionId { get; set; }

        [Column("BecarioId")]
        [Required]
        [ForeignKey("Becario")]
        public int BecarioId { get; set; }

        [Column("TipoPruebaId")]
        [Required]
        [ForeignKey("TipoPrueba")]
        public int TipoPruebaId { get; set; }

        [Column("TipoResultadoId")]        
        [ForeignKey("TipoResultado")]
        public int? TipoResultadoId { get; set; }

        [Column("FechaConvocatoria")]       
        public DateTime? FechaConvocatoria { get; set; }

        [Column("PersonaConvocatoriaNombre")] 
        public string PersonaConvocatoriaNombre { get; set; }

        [Column("PersonaConvocatoriaId")]
        [ForeignKey("PersonaConvocatoria")]
        public int? PersonaConvocatoriaId { get; set; }      

        [Column("Observaciones")]
        [MaxLength]
        public string Observaciones { get; set; }

        #endregion

        #region Navigation Properties

        [NavigationProperty]
        public virtual Becario Becario { get; set; }

        [NavigationProperty]
        public virtual Maestro TipoPrueba { get; set; }

        [NavigationProperty]
        public virtual Maestro TipoResultado { get; set; }

        [NavigationProperty]
        public virtual Usuario PersonaConvocatoria { get; set; }       


        #endregion

    }
}
