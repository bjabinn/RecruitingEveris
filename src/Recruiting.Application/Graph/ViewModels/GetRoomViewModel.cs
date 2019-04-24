using System;

namespace Recruiting.Application.Graph.ViewModels
{
    public class GetRoomViewModel
    {
        public int CentroId { get; set; }
        public int? OficinaId { get; set; }
        public int EntrevistadorId { get; set; }
        public DateTime Fecha { get; set; }
        public bool IgnorarDisponibilidad { get; set; }

    }
}