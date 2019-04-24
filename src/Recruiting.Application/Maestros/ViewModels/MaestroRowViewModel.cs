using System;

namespace Recruiting.Application.Maestros.ViewModels
{
    [Serializable]
    public class MaestroRowViewModel
    {
        public int MaestroId { get; set; }
        public int TipoMaestroId { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public int? Orden { get; set; }
    }
}
