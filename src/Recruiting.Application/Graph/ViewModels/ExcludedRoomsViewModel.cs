using System.Collections.Generic;

namespace Recruiting.Application.Graph.ViewModels
{
    public class ExcludedRoomsViewModel
    {
        public int CentroId { get; set; }
        public int? OficinaId { get; set; }
        public List<ExcludedRoomViewModel> ExcludedRooms { get; set; }

    }
}