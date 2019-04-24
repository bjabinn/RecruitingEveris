using Microsoft.Identity.Client;
using System;

namespace Microsoft_Graph_REST_ASPNET_Connect.Models
{
    public class TestClass : IUser
    {
        public string DisplayableId { get; set; }
        public string Identifier { get; set; }
        public string IdentifyProvider { get; set; }

        public string IdentityProvider
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name { get; set; }
    }
}