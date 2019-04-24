using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    [Serializable]
    public class ResultadoSegundaEntrevista
    {
        public int? MotivoId { get; set; }
        public string MotivoNombre { get; set; }
        public int? SuperaEntrevista2Id { get; set; }
        public bool NotificarDescarte { get; set; }

        public string AccessResultado2 { get; set; }
        public IEnumerable<SelectListItem> MotivoDescarteList { get; set; }
    }
}
