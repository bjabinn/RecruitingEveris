using Recruiting.Infra.Caching.Contracts;
using System.Web;

namespace Recruiting.Infra.Caching
{
    public class SessionCacheStorageService : ICacheStorageService
    {
        public void Add(string key, object data)
        {
            HttpContext.Current.Session[key] = data;
        }

        public T Get<T>(string key)
        {
            if (HttpContext.Current.Session != null)
            {
                if (HttpContext.Current.Session[key] != null)
                {
                    if (HttpContext.Current.Session[key] is T)
                    {
                        return (T)HttpContext.Current.Session[key];
                    }
                }
            }
            return default(T);
        }

        public void Remove(string key)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                HttpContext.Current.Session.Remove(key);
            }
        }
    }
}
