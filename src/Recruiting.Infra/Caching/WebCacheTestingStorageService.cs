using System;
using System.Collections;
using Recruiting.Infra.Caching.Contracts;

namespace Recruiting.Infra.Caching
{
    public class WebCacheTestingStorageService : IWebCacheStorageService
    {
        [ThreadStatic] 
        private static IDictionary _storage;


        IDictionary Storage
        {
            get { return _storage ?? (_storage = new Hashtable()); }
        }

        public void Add(string key, object data)
        {
            if (Storage.Contains(key)) Storage[key] = data;
            else Storage.Add(key,data);
        }

        public T Get<T>(string key)
        {
            if (Storage.Contains(key))
            {
                if (Storage[key] is T)
                {
                    return (T)Storage[key];
                }
            }
            return default(T);
        }

        public void Remove(string key)
        {
            if (!Storage.Contains(key)) Storage.Remove(key);
        }

        public bool IsAvailable()
        {
            return true;
        }
    }

}
