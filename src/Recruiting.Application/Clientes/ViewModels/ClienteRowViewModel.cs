using System;

namespace Recruiting.Application.Clientes.ViewModels
{
    [Serializable]
    public class ClienteRowViewModel
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }
}
