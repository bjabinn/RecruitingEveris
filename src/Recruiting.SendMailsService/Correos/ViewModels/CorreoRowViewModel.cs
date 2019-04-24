using System;

namespace Recruiting.SendMailsService.Correos.ViewModels
{
    [Serializable]
    public class CorreoRowViewModel
    {
        public int CorreoId { get; set; }

        public int PlantillaId { get; set; }

        public int CandidaturaId { get; set; }

        public string Asunto { get; set; }

        public string Destinatarios { get; set; }

        public string Remitente { get; set; }

        public bool Enviado { get; set; }

        public DateTime? FechaEnvio { get; set; }

        public bool Activo { get; set; }

        public int? SubEntrevistaId { get; set; }

        public string TipoAviso { get; set; }
    }
}
 
