using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    [Serializable]
    public class AgendarSegundaEntrevistaViewModel
    {
        public AgendarSegundaEntrevista AgendarSegundaEntrevista { get; set; }
        public List<SubEntrevistaViewModel> SubEntrevistaList { get; set; }
        public IEnumerable<SelectListItem> TipoSubEntrevistaList { get; set; }

        public int? AccessEtapa { get; set; }
        public string AccessAgendar2 { get; set; }
    }
}
