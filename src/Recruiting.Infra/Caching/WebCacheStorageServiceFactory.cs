using Recruiting.Infra.Caching.Contracts;

namespace Recruiting.Infra.Caching
{
    public static class WebCacheStorageServiceFactory
    {
        #region Fields
        private static IWebCacheStorageService _webCacheStorageService;
        #endregion


        #region Methods
        public static void Initialize(IWebCacheStorageService webCacheStorageService)
        {
            _webCacheStorageService = webCacheStorageService;
        }

        public static IWebCacheStorageService Current
        {
            get { return _webCacheStorageService; }
        }

        #endregion

    }
}
