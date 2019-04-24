using System;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    public class SubEntrevistaViewModel
    {
        public int? SubEntrevistaId { get; set; }
        public int? EntrevistaId { get; set; }
        public int? EntrevistadorId { get; set; }
        public string EntrevistadorName { get; set; }
        public DateTime? FechaSubEntrevista { get; set; }
        public bool Completada { get; set; }
        public string Observaciones { get; set; }
        public int? TipoSubEntrevistaId { get; set; }
        public string TipoSubEntrevistaNombre { get; set; }
        public decimal? SalarioPropuesto { get; set; }
        public decimal? SalarioDeseado { get; set; }
        public decimal? SalarioActual { get; set; }
        public int? IncorporacionId { get; set; }
        public string IncorporacionNombre { get; set; }
        public bool DisponibilidadViajes { get; set; }
        public bool CambioResidencia { get; set; }
        public int? CategoriaId { get; set; }
        public string CategoriaNombre { get; set; }
        public bool Presencial { get; set; }
        public bool SuperaSubEntrevista { get; set; }
        public bool AvisarAlCandidato { get; set; }
        public bool Activo { get; set; }

    }
}
