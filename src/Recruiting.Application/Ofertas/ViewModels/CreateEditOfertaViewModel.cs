using System;

namespace Recruiting.Application.Ofertas.ViewModels
{
    [Serializable]
    public class CreateEditOfertaViewModel
    {
        public int? OfertaId { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public DateTime? FechaPublicacion { get; set; }

        public int EstadoOfertaId { get; set; }

        public bool Activo { get; set; }
    }
}
