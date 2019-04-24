using System;
using System.Collections.Generic;

namespace Microsoft_Graph_REST_ASPNET_Connect.Models
{
    public class EventoRowViewModel
    {
        public List<string> Destinatarios { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string Body { get; set; }
        public string Asunto { get; set; }
        public string Localizacion { get; set; }
        public Guid identificador { get; set; }
    }
}