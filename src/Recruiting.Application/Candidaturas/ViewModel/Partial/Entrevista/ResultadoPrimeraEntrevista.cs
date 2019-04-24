using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Recruiting.Application.Candidaturas.ViewModel
{
    [Serializable]
    public class ResultadoPrimeraEntrevista
    {
        public int? MotivoId { get; set; }
        public string MotivoNombre { get; set; }
        public int? SuperaEntrevistaId { get; set; }

        public int? ResultadoTest { get; set; }
        public string NombreTS { get; set; }
        public bool subidoTS { get; set; }
        public byte[] TS { get; set; }
        public bool Completada { get; set; }
        public bool NotificarDescarte { get; set; }

        public string AccessResultado { get; set; }
        public IEnumerable<SelectListItem> MotivoDescarteList {get;set;}
    }
}
