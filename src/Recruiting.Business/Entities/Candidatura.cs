using EverNext.Domain.Model.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("Candidatura")]
    public class Candidatura : ModifiableEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("CandidaturaId")]
        public int CandidaturaId { get; set; }

        [Column("OfertaId")]
        [ForeignKey("Oferta")]
        public int? OfertaId { get; set; }

        [Column("FuenteReclutamientoId")]
        [ForeignKey("FuenteReclutamiento")]
        public int? FuenteReclutamientoId { get; set; }

        [Column("OrigenCvId")]
        [ForeignKey("OrigenCv")]
        public int? OrigenCvId { get; set; }

        [Column("CandidatoId")]
        [Required]
        [ForeignKey("Candidato")]
        public int CandidatoId { get; set; }

        [Column("EtapaCandidaturaId")]
        [Required]
        [ForeignKey("EtapaCandidatura")]
        public int EtapaCandidaturaId { get; set; }

        [Column("EstadoCandidaturaId")]
        [Required]
        [ForeignKey("EstadoCandidatura")]
        public int EstadoCandidaturaId { get; set; }

        [Column("TipoPerfilDeseadoId")]
        [ForeignKey("TipoPerfilDeseado")]
        public int? TipoPerfilDeseadoId { get; set; }

        [Column("TipoPerfilId")]
        [ForeignKey("TipoPerfil")]
        public int? TipoPerfilId { get; set; }

        [Column("IncorporacionId")]
        [ForeignKey("Incorporacion")]
        public int? IncorporacionId { get; set; }

        [Column("CategoriaId")]
        [ForeignKey("Categoria")]
        public int? CategoriaId { get; set; }
                
        [Column("SalarioPropuesto")]
        public decimal? SalarioPropuesto { get; set; }
        
        [Column("Observaciones")]
        [MaxLength]
        public string Observaciones { get; set; }
        
        [Column("DatosCurriculo")]
        [MaxLength]
        public string DatosCurriculo { get; set; }
        
        [Column("CV")]
        public byte[] CV { get; set; }
        
        [Column("NombreCV")]
        [MaxLength]
        public string NombreCV { get; set; }

        [Column("UrlCV")]
        public string UrlCV { get; set; }

        [Column("SalarioDeseado")]
        public decimal? SalarioDeseado { get; set; }
        
        [Column("FiltradoCV")]
        [Required]
        public bool FiltradoCV { get; set; }

        [Column("FiltradorId")]
        [ForeignKey("Filtrador")]
        public int? FiltradorId { get; set; }

        [Column("DescartarFuturasCandidaturas")]
        [Required]
        public bool DescartarFuturasCandidaturas { get; set; }
        
        [Column("SalarioActual")]
        public decimal? SalarioActual { get; set; }
        
        [Column("DisponibilidadViajes")]
        [Required]
        public bool DisponibilidadViajes { get; set; }
        
        [Column("CambioResidencia")]
        [Required]
        public bool CambioResidencia { get; set; }

        [Column("NecesidadIdioma")]
        [Required]
        public bool NecesidadIdioma { get; set; }

        [Column("TipoTecnologiaId")]
        [ForeignKey("TipoTecnologia")]
        public int? TipoTecnologiaId { get; set; }
		
        [Column("MotivoRenunciaDescarteId")]
        [ForeignKey("MotivoRenunciaDescarte")]
        public int? MotivoRenunciaDescarteId { get; set; }

        [Column("ModuloId")]
        [ForeignKey("TipoModulo")]
        public int? ModuloId { get; set; }

        [Column("Moneda")]
        [StringLength(3)]
        public string Moneda { get; set; }

        [Column("NumeroDeEntrevistas")]        
        public int? NumeroDeEntrevistas { get; set; }

        [Column("ComentariosRenunciaDescarte")]
        public string ComentariosRenunciaDescarte { get; set; }

        [Column("FechaContactoStandBy")]
        public DateTime? FechaContactoStandBy { get; set; }

        [Column("EmailsSeguimiento")]
        public string EmailsSeguimiento { get; set; }

        [Column("EmailsReferenciados")]
        public string EmailsReferenciados { get; set; }

        [Column("NotificarDescarte")]
        public bool NotificarDescarte { get; set; }

        [Column("CandidaturaOfertaId")]
        [ForeignKey("CandidaturaOferta")]
        public int? CandidaturaOfertaId { get; set; }

        [Column("UbicacionCandidato")]
        public string UbicacionCandidato { get; set; }

        [Column("AniosExperiencia")]
        public DateTime? AniosExperiencia { get; set; }

        #endregion

        #region Navigation Properties

        [NavigationProperty]
        public virtual Oferta Oferta { get; set; }

        [NavigationProperty]
        public virtual Candidato Candidato { get; set; }

        [NavigationProperty]
        public virtual TipoEtapaCandidatura EtapaCandidatura { get; set; }

        [NavigationProperty]
        public virtual TipoEstadoCandidatura EstadoCandidatura { get; set; }

        [NavigationProperty]
        public virtual Maestro TipoPerfilDeseado { get; set; }

        [NavigationProperty]
        public virtual Maestro TipoPerfil { get; set; }

        [NavigationProperty]
        public virtual Maestro Incorporacion { get; set; }

        [NavigationProperty]
        public virtual Maestro Categoria { get; set; }

        [NavigationProperty]
        public virtual Maestro FuenteReclutamiento { get; set; }

        [NavigationProperty]
        public virtual Maestro OrigenCv { get; set; }


        [NavigationProperty]
        public virtual ICollection<CartaOferta> CartaOfertas { get; set; }

        [NavigationProperty]
        public virtual ICollection<Entrevista> Entrevistas { get; set; }

        [NavigationProperty]
        public virtual Maestro TipoTecnologia { get; set; }

        [NavigationProperty]
        public virtual Maestro MotivoRenunciaDescarte { get; set; }

        [NavigationProperty]
        public virtual Maestro TipoModulo { get; set; }

        [NavigationProperty]
        public virtual Usuario Filtrador { get; set; }

        [NavigationProperty]
        public virtual CandidaturaOferta CandidaturaOferta { get; set; }
        #endregion
    }
}
