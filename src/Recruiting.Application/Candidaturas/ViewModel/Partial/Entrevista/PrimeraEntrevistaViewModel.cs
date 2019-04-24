using System;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    [Serializable]
    public class PrimeraEntrevistaViewModel
    {
        public AgendarPrimeraEntrevistaViewModel AgendarPrimeraEntrevista { get; set; }
        public RangoSalarialesyDisponibilidades RangoSalarialesyDisponibilidades { get; set; }
        public ResultadoPrimeraEntrevista ResultadoPrimeraEntrevista { get; set; }

        public bool MostrarRangosSalariales { get; set; }
        public int? AccessEtapa { get; set; }
        public int? AccessEstado { get; set; }
        public string NombreCandidato { get; set; }
    }
}
