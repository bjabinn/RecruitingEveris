using System.Collections.Generic;

namespace Microsoft_Graph_REST_ASPNET_Connect.Models
{
    public class GraphModel
    {
        public List<Sala> Salas { get; set; }
        public string SalaSeleccionada { get; set; }
    }
}