using System;

namespace Recruiting.Application.Dashboard.ViewModels
{
    [Serializable]
    public class EntrevistasPlanificadasRowViewModel
    {
        public String title{ get; set; }
        public String url { get; set; }
        public String start { get; set; }
        
        public string className { get; set; }
        public bool? Finalizada { get; set; }
        public int CandidaturaId { get; set; }
        public int? TipoEntrevistaProgramada { get; set; }
    }
}
