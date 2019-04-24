using System;
using System.Collections.Generic;
using System.Drawing;

namespace Recruiting.Application.Graph.ViewModels
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
        public string From { get; set; }
        public Image Attachment { get; set; }

        public string nombreAttachment { get; set; }
    }
}