using System;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    [Serializable]
    public class SegundaEntrevistaViewModel
    {
        public AgendarSegundaEntrevistaViewModel AgendarSegundaEntrevista { get; set; }
        public RangoSalarialesyDisponibilidades RangoSalarialesyDisponibilidades { get; set; }
        public ResultadoSegundaEntrevista ResultadoSegundaEntrevista { get; set; }
        public string NombreCandidato { get; set; }

        public bool MostrarRangosSalariales { get; set; }

        public int? AccessEtapa { get; set; }
        public int? AccessEstado { get; set; }
    }
}
