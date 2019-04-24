using System;

namespace Recruiting.Application.Bitacoras.ViewModels
{
    [Serializable]
    public class BitacoraRowViewModel
    {
        public int BitacoraId { get; set; }

        public int CandidaturaId { get; set; }

        public string TipoCambio { get; set; }
        
        public string MensajeSistema { get; set; }
     
        public string Usuario { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string Centro { get; set; }
    }
}
