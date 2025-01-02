using Microsoft.Extensions.Caching.Memory;

namespace Udemy.Web.Caching
{
    public class InMemoryCacheService(IMemoryCache memoryCache) : ICacheService
    {
        public Task Set<T>(string key, T value)// Set<T> methodu ile cache'e veri ekleyebiliriz.Burada  sepet listesini tutmak için key ve value parametrelerini kullanıyoruz.
        {
            memoryCache.Set<T>(key, value);//memoryCache'e veri ekliyoruz.
            return Task.CompletedTask;//Task.CompletedTask ile işlem tamamlandığında geriye bir task döndürüyoruz.

        }

        public Task<T?> Get<T>(string key)
        {
            return Task.FromResult(memoryCache.Get<T>(key)); 
        }


        

      public Task Remove(string key)
        {
            memoryCache.Remove(key);
            return Task.CompletedTask;
        }
    }
    
    
}
