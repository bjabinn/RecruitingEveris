using System.Web;
using Recruiting.Infra.Caching.Contracts;
using Recruiting.Infra.Caching.Exceptions;

namespace Recruiting.Infra.Caching
{
    public class WebCacheStorageService : IWebCacheStorageService
    {
        public void Add(string key, object data)
        {
            if (HttpContext.Current == null)
            {
                throw new StoreNotAvailableException("HttpContext.Current is not available");
            }

            if (HttpContext.Current.Items.Contains(key))
            {
                HttpContext.Current.Items[key] = data;
            }
            else
            {
                HttpContext.Current.Items.Add(key, data);
            }
        }

        public T Get<T>(string key)
        {
            if (HttpContext.Current == null)
            {
                throw new StoreNotAvailableException("HttpContext.Current is not available");
            }


            if (HttpContext.Current.Items.Contains(key))
            {
                if (HttpContext.Current.Items[key] is T)
                {
                    return (T) HttpContext.Current.Items[key];
                }
            }
            return default(T);
        }

        public void Remove(string key)
        {
            if (HttpContext.Current == null)
            {
                throw new StoreNotAvailableException("HttpContext.Current is not available");
            }

            if (!HttpContext.Current.Items.Contains(key))
            {
                HttpContext.Current.Items.Remove(key);
            }
        }

        public bool IsAvailable()
        {
            return HttpContext.Current != null;
        }
    }
}