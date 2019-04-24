using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Infra.Caching.Exceptions
{
    public class StoreNotAvailableException : Exception
    {

        public StoreNotAvailableException(string message) : base(message)
        {
            
        }
    }
}
