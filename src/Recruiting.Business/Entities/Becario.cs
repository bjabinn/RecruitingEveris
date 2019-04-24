using EverNext.Domain.Model.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.Business.Entities
{
    [Table("Becario")]
    public class Becario : ModifiableEntity
    {
        #region Scalar Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("BecarioId")]
        public int BecarioId { get; set; }

        [Column("CandidatoId")]
        [Required]
        [ForeignKey("Candidato")]
        public int CandidatoId { get; set; }

        [Column("TipoBecarioId")]
        [Required]
        [ForeignKey("TipoBecario")]
        public int TipoBecarioId { get; set; }

        [Column("CV")]
        public byte[] CV { get; set; }

        [Column("NombreCV")]
        [MaxLength]
        public string NombreCV { get; set; }

        [Column("UrlCV")]
        public string UrlCV { get; set; }

        [Column("TipoEstadoBecarioId")]
        [Required]
        [ForeignKey("TipoEstadoBecario")]
        public int TipoEstadoBecarioId { get; set; }

        [Column("BecarioCentroProcedenciaId")]
        [ForeignKey("BecarioCentroProcedencia")]
        public int? BecarioCentroProcedenciaId { get; set; }

        [Column("FechaContactoStandBy")]
        public DateTime? FechaContactoStandBy { get; set; }

        [Column("ObservacionFinalProceso")]
        public string ObservacionFinalProceso { get; set; }

        [Column("SuperaProceso")]
        public bool SuperaProceso { get; set; }

        [Column("FechaBecaInicio")]
        public DateTime? FechaBecaInicio { get; set; }

        [Column("FechaBecaFin")]
        public DateTime? FechaBecaFin { get; set; }

        [Column("FechaBecaFinReal")]
        public DateTime? FechaBecaFinReal { get; set; }

        [Column("NumHoras")]
        public int? NumHoras { get; set; }

        [Column("Anexo")]
        public byte[] Anexo { get; set; }

        [Column("NombreAnexo")]
        [MaxLength]
        public string NombreAnexo { get; set; }

        [Column("UrlAnexo")]
        public string UrlAnexo { get; set; }

        [Column("TutorId")]
        [ForeignKey("Tutor")]
        public int? TutorId { get; set; }

        [Column("TutorNombre")]
        public string TutorNombre { get; set; }

        [Column("ResponsableNombre")]
        public string ResponsableNombre { get; set; }

        [Column("ResponsableId")]
        [ForeignKey("Responsable")]
        public int? ResponsableId { get; set; }

        [Column("ClienteId")]
        [ForeignKey("Cliente")]
        public int? ClienteId { get; set; }

        [Column("ProyectoId")]
        [ForeignKey("Proyecto")]
        public int? ProyectoId { get; set; }

        [Column("CompletadoGestion")]
        public bool CompletadoGestion { get; set; }

        [Column("CompletadoAsignacion")]
        public bool CompletadoAsignacion { get; set; }

        [Column("TipoAsistenciaId")]
        [ForeignKey("TipoAsistencia")]
        public int? TipoAsistenciaId { get; set; }

        [Column("TipoDecisionFinalId")]
        [ForeignKey("TipoDecisionFinal")]
        public int? TipoDecisionFinalId { get; set; }

        [Column("ObservacionFinalPracticas")]
        public string ObservacionFinalPracticas { get; set; }

        [Column("ComentariosRenunciaDescarte")]
        public string ComentarioRenunciaDescarte { get; set; }

        [Column("BecarioConvocatoriaId")]
        [ForeignKey("BecarioConvocatoria")]
        public int? BecarioConvocatoriaId { get; set; }

        [Column("OrigenCvId")]
        [ForeignKey("OrigenCv")]
        public int? OrigenCvId { get; set; }

        [Column("FuenteReclutamientoId")]
        [ForeignKey("FuenteReclutamiento")]
        public int? FuenteReclutamientoId { get; set; }

        [Column("EmailsReferenciados")]
        public string EmailsReferenciados { get; set; }

        [Column("NotificarDescarte")]
        public bool NotificarDescarte { get; set; }

        #endregion

        #region Navigation Properties

        [NavigationProperty]
        public virtual Candidato Candidato { get; set; }

        [NavigationProperty]
        public virtual Maestro TipoBecario { get; set; }

        [NavigationProperty]
        public virtual TipoEstadoBecario TipoEstadoBecario { get; set; }

        [NavigationProperty]
        public virtual BecarioCentroProcedencia BecarioCentroProcedencia { get; set; }

        [NavigationProperty]
        public virtual Cliente Cliente { get; set; }

        [NavigationProperty]
        public virtual Proyecto Proyecto { get; set; }

        [NavigationProperty]
        public virtual Usuario Tutor { get; set; }

        [NavigationProperty]
        public virtual Usuario Responsable { get; set; }

        [NavigationProperty]
        public virtual Maestro TipoAsistencia { get; set; }

        [NavigationProperty]
        public virtual Maestro TipoDecisionFinal { get; set; }

        [NavigationProperty]
        public virtual BecarioConvocatoria BecarioConvocatoria { get; set; }

        [NavigationProperty]
        public virtual Maestro OrigenCv { get; set; }

        [NavigationProperty]
        public virtual Maestro FuenteReclutamiento { get; set; }

        #endregion
    }
}
