using Akavache;
using ConnectNow.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

namespace ConnectNow.LocalCache
{
    public class AkavacheLocalCache : ILocalCache
    {
        private static IBlobCache Local => CacheDatabase.LocalMachine;

        public async Task<T?> GetCacheItem<T>(string id)
        {
            try { return await Local.GetObject<T>(id).ToTask(); }
            catch (KeyNotFoundException) { return default; }
        }

        public Task SaveItemInCache<T>(string id, T item) =>
            Local.InsertObject(id, item).ToTask();

        public Task DeleteItem<T>(string id) =>
            Local.InvalidateObject<T>(id).ToTask();

        public async Task ClearAllAsync()
        {
            await Local.InvalidateAll().ToTask();
            await Local.Vacuum().ToTask();
        }

    }

}

