using System;

namespace Recruiting.Application.Becarios.ViewModels
{
    [Serializable]
    public class BecarioEstadoRowViewModel
    {
        public int BecarioEstadoId { get; set; }
        public string BecarioEstado { get; set; }
        public int? Orden { get; set; }
    }
}
