using System;

namespace Recruiting.Application.Bitacoras.ViewModels
{
    [Serializable]
    public class BitacoraCorreoViewModel
    {
        public int BitacoraId { get; set; }

        public int CandidaturaId { get; set; }

        public string TipoCambio { get; set; }
        
        public string MensajeSistema { get; set; }
     
        public int? Usuario { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? EstadoAnterior { get; set; }

        public int? EstadoNuevo { get; set; }

        public int? EtapaAnterior { get; set; }

        public int? EtapaNueva { get; set; }

    }
}
