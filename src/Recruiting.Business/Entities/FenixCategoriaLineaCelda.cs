using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("FenixCategoriaLineaCelda")]
    public class FenixCategoriaLineaCelda : ModifiableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("FenixCategoriaLineaCeldaId")]
        public int FenixCategoriaLineaCeldaId { get; set; }

        [Column("Nombre")]
        [Required]
        [StringLength(500)]
        public string Nombre { get; set; }

        [Column("Tipo")]
        [Required]
        [StringLength(10)]
        public string Tipo { get; set; }
    }
}
