using System.Collections.Generic;

namespace Recruiting.Application.Graph.Messages
{
    public class FindRoomsListResponse
    {
        public List<Value> value { get; set; }
    }

    public class Value
    {
        public string name { get; set; }
        public string address { get; set; }
    }
}