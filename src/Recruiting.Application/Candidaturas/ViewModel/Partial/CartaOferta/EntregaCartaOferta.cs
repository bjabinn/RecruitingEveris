using System;

namespace Recruiting.Application.Candidaturas.ViewModel

{
    [Serializable]
    public class EntregaCartaOferta
    {
        public decimal SalarioPropuesto { get; set; }
        public decimal SalarioActual { get; set; }
        public decimal SalarioDeseado { get; set; }
        public string ObservacionesCartaOferta { get; set; }
        public string Moneda { get; set; }

        public string AccessEntrega { get; set; }
    }
}
