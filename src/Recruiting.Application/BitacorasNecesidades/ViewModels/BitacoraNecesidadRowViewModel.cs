using System;

namespace Recruiting.Application.BitacorasNecesidades.ViewModels
{
    [Serializable]
    public class BitacoraNecesidadRowViewModel
    {
        public int BitacoraId { get; set; }

        public int NecesidadId { get; set; }

        public string TipoCambio { get; set; }
        
        public string MensajeSistema { get; set; }
     
        public string Usuario { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string Centro { get; set; }
    }
}
