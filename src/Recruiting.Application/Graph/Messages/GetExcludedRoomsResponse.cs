using Recruiting.Application.Base;
using Recruiting.Application.Graph.ViewModels;

namespace Recruiting.Application.Graph.Messages
{
    public class GetExcludedRoomsResponse : ApplicationResponseBase
    {
        public ExcludedRoomsViewModel ExcludedRoomsList { get; set; }
    }
}