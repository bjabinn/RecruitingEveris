using System;

namespace Recruiting.Application.BitacorasBecarios.ViewModels
{
    [Serializable]
    public class BitacoraBecariosRowViewModel
    {
        public int BitacoraId { get; set; }

        public int BecarioId { get; set; }

        public string TipoCambio { get; set; }
        
        public string MensajeSistema { get; set; }
     
        public string Usuario { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string Centro { get; set; }
    }
}
