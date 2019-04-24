﻿using Recruiting.Infra.RepositoryBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("TipoMaestro")]
    public class TipoMaestro : BaseEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("TipoMaestroId")]
        public int TipoMaestroId { get; set; }

        [Column("TipoMaestro")]
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        #endregion

    }
}
