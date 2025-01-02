namespace Udemy.Web.Caching
{
    public interface ICacheService// Bu interface ile cache işlemlerini gerçekleştireceğimiz metotları tanımlayabiliriz.
    {
        Task Set<T>(string key, T value);// Set<T> methodu ile cache'e veri ekleyebiliriz.Burada  sepet listesini tutmak için key ve value parametrelerini kullanıyoruz.

        Task<T?> Get<T>(string key);// Get<T> methodu ile cache'den veri alabiliriz.

        Task Remove(string key);// Remove methodu ile cache'den veri silebiliriz.
    }
}
