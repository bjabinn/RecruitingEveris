using Recruiting.Infra.Caching.Contracts;

namespace Recruiting.Infra.Caching
{
    public static class CacheStorageFactory
    {
        #region Fields
        private static ICacheStorageService _cacheStorageService;
        #endregion


        #region Methods
        public static void Initialize(ICacheStorageService cacheStorageService)
        {
            _cacheStorageService = cacheStorageService;
        }

        public static ICacheStorageService Current
        {
            get { return _cacheStorageService; }
        }

        #endregion

    }
}
