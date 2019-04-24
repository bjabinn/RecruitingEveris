using System;

namespace Recruiting.Application.Graph.ViewModels
{
    public class SendMeetingSubEntrevistasViewModel
    {
        public bool Presencial { get; set; }
        public int TipoSubEntrevista { get; set; }
        public int EntrevistadorId { get; set; }
        public string Entrevistador { get; set; }
        public DateTime Fecha { get; set; }

    }
}