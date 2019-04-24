using System;

namespace Recruiting.SendMailsService.Correos.ViewModels
{
    [Serializable]
    public class CorreoBecarioRowViewModel
    {
        public int CorreoId { get; set; }

        public int PlantillaId { get; set; }

        public int? BecarioId { get; set; }

        public string Asunto { get; set; }

        public string Destinatarios { get; set; }

        public string Remitente { get; set; }

        public bool Enviado { get; set; }

        public DateTime? FechaEnvio { get; set; }

        public bool Activo { get; set; }

        public string TipoAviso { get; set; }
    }
}
 
