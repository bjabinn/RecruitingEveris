using EverNext.Domain.Model.Attributes;
using Recruiting.Infra.RepositoryBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("BlackListSala")]
    public class BlackListSala : BaseEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("BlackListSalaId")]
        public int BlackListSalaId { get; set; }       

        [Column("Salas")]            
        public string Salas { get; set; }

        [Column("CentroId")]
        [ForeignKey("Centro")]
        [Required]
        public int CentroId { get; set; }

        [Column("OficinaId")]
        [ForeignKey("Oficina")]      
        public int? OficinaId { get; set; }


        #endregion

        #region Navigation Properties

        public virtual Centro Centro { get; set; }

        public virtual Oficina Oficina { get; set; }


        #endregion
    }
}
