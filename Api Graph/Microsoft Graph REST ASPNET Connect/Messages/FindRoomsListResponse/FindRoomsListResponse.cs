using System.Collections.Generic;

namespace Microsoft_Graph_REST_ASPNET_Connect.Models.Messages.FindRoomsListResponse
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