namespace ConnectNow.LocalCache
{
    public interface ILocalCache
	{
        Task<T> GetCacheItem<T>(string id);
        Task SaveItemInCache<T>(string id, T item);
        Task DeleteItem<T>(string id);
        Task ClearAllAsync();
        
    }
}

