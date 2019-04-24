using System;

namespace Recruiting.SendMailsService.Correos.ViewModels
{
    [Serializable]
    public class CorreoPlantillaVariableRowViewModel
    {
        public string Asunto { get; set; }

        public string Remitente { get; set; }

        public string imagenFirma { get; set; }

        public string LogoCabecera { get; set; }

        public string NombreCandidato { get; set; }
        
        //para las firmas de los correos de cada uno de los centros
        public string LineaTituloPie { get; set; }
        public string LineaDireccion { get; set; }
        public string LineaProvincia { get; set; }
        public string LineaTelefono { get; set; }
        public string LineaEmail { get; set; }
        public string LineaWeb { get; set; }


        public string NombreEntrevistador { get; set; }
        public string TipoEntrevista { get; set; }
        public DateTime? FechaEntrevista { get; set; }
        public int? CandidaturaId { get; set; }
        public string UrlRecruiting { get; set; }

        public string SoloFecha { get; set; }
        public TimeSpan? SoloHora { get; set; }
        public string MensajeSistema { get; set; }
        public string Candidato { get; set; }
    }
}
 
