using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Infra.Caching.Contracts
{
    public interface ICacheStorageService
    {        
        void Add(string key, object data);
        
        T Get<T>(string key);
   
        void Remove(string key);     
    }
}
