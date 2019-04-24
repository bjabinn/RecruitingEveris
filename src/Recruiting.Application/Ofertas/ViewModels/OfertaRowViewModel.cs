using System;

namespace Recruiting.Application.Ofertas.ViewModels
{
    [Serializable]
    public class OfertaRowViewModel
    {
        public int OfertaId { get; set; }

        public string Nombre { get; set; }

        public int? Candidatos { get; set; }

        public string Estado { get; set; }

        public DateTime? FechaPublicacion { get; set; }

        public string Centro { get; set; }


    }
}
