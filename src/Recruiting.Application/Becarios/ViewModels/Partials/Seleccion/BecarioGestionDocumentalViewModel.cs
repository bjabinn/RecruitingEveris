using System;

namespace Recruiting.Application.Becarios.ViewModels
{
    [Serializable]
    public class BecarioGestionDocumentalViewModel
    {      

        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? NumHoras { get; set; }
        public DateTime? FechaFinReal { get; set; }
        public bool SubidoAnexo { get; set; }
        public string NombreAnexo { get; set; }
        public byte[] Anexo { get; set; }
        public string UrlAnexo { get; set; }

        public string AccessGestion { get; set; }

    }
}
