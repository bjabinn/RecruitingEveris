using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.Becarios.ViewModels
{
    [Serializable]
    public class BecarioDatosPracticasViewModel
    {
        public int? BecarioId { get; set; }
        public int? DecisionFinalId { get; set; }
        public string DecisionFinalNombre { get; set; }
        public string ObservacionFinalPracticas { get; set; }

        public IEnumerable<SelectListItem> TipoDecisionFinalPracticas { get; set; }
        public string AccessPracticas { get; set; }
        public string NombreCandidato { get; set; }
    }
}
