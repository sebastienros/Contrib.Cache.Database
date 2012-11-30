using Contrib.Cache.Services;
using Orchard.Tasks;

namespace Contrib.Cache.Database.Services {
    public class DatabaseOutputCacheBackgroundTask : IBackgroundTask {
        private readonly IOutputCacheStorageProvider _outputCacheStorageProvider;

        public DatabaseOutputCacheBackgroundTask(IOutputCacheStorageProvider outputCacheStorageProvider) {
            _outputCacheStorageProvider = outputCacheStorageProvider;
        }

        public void Sweep() {
            var provider = _outputCacheStorageProvider as DatabaseOutputCacheStorageProvider;
            if (provider != null) {
                provider.RemoveExpiredEntries();
            }
        }
    }
}