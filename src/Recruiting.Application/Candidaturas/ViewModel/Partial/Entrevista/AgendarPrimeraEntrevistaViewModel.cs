using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    [Serializable]
    public class AgendarPrimeraEntrevistaViewModel
    {
        public AgendarPrimeraEntrevista AgendarPrimeraEntrevista { get; set; }
        public List<SubEntrevistaViewModel> SubEntrevistaList { get; set; }
        public IEnumerable<SelectListItem> TipoSubEntrevistaList { get; set; }
        public int? AccessEtapa { get; set; }
        public string AccessAgendar1 { get; set; }
        public string NombreCandidato { get; set; }
    }
}
