using Recruiting.Application.Base;

namespace Recruiting.Application.Graph.Messages
{
    public class GetStringExcludedRoomsResponse : ApplicationResponseBase
    {
        public string StringExcludedRooms { get; set; }
    }
}