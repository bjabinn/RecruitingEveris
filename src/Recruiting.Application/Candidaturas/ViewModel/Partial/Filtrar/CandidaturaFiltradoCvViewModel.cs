using System;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    [Serializable]
    public class CandidaturaFiltradoCvViewModel
    {
        public int CandidaturaId { get; set; }
        public bool Filtrado { get; set; }
        public string MotivosObservaciones { get; set; }
        public bool DescartarFuturasCandidaturas { get; set; }
        public string NombreCandidato { get; set; }
        public string UbicacionCandidato { get; set; }

        public string AccessFiltro { get; set; }
    }
}
