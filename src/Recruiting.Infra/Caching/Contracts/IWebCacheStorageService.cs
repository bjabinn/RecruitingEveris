
namespace Recruiting.Infra.Caching.Contracts
{
    public interface IWebCacheStorageService
    {        
        void Add(string key, object data);
        
        T Get<T>(string key);
   
        void Remove(string key);

        bool IsAvailable();
    }
}
