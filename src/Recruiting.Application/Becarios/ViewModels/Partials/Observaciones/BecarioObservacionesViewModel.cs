using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.Becarios.ViewModels
{
    [Serializable]
    public class BecarioObservacionesViewModel
    {
        public int BecarioId { get; set; }
        public List<BecarioObservacionViewModel> BecarioObservacionList { get; set; }    
        public string ObservacionGeneralProceso { get; set; }
        public bool SuperaProceso { get; set; }
        public string[] ObservacionesBorradas { get; set; }

        public IEnumerable<SelectListItem> TipoPruebaList { get; set; }
        public IEnumerable<SelectListItem> TipoResultadoList { get; set; }
        public string AccessObservaciones { get; set; }
        public string NombreCandidato { get; set; }
    }
}
