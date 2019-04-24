using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Application.Oferta.ViewModels
{
    [Serializable]
    public class OfertaRowViewModel
    {
        public int? OfertaId { get; set; }

        public string Nombre { get; set; }

        public string Candidatos { get; set; }

        public string Estado { get; set; }

        public DateTime FechaPublicacion { get; set; }
    }
}
