namespace Udemy.Web.Models.Services
{
    public class ServiceResult<T>
    {
        public T? Data { get; set; }//Bu property ile işlem sonucunda dönecek olan veriyi tutacağız.

        public List<string>? Errors { get; set; }//Bu property ile hata mesajlarını tutacağız.Amaç hata oluştuğunda bu property üzerinden hata mesajlarını dönebilmek.

        public string? SuccessMessage { get; set; }//Bu property ile işlem başarılı olduğunda dönecek olan mesajı tutacağız.Amaç işlem başarılı olduğunda bu property üzerinden mesaj dönebilmek.

        public bool IsFail => Errors is not null && Errors.Count > 0;//Eğer hata varsa IsFail true döner.BU property ile hata olup olmadığını kontrol edebiliriz.
        public bool IsSuccess => !IsFail;//Eğer hata yoksa IsSuccess true döner.Bu property ile işlem başarılı mı değil mi kontrol edebiliriz.

        public static ServiceResult<T> Success(T data, string? successMessage)//Bu method ile işlem başarılı olduğunda dönecek olan veriyi ve mesajı döneceğiz.
        {
            return new ServiceResult<T>//ServiceResult tipinde bir nesne oluşturup geriye döneceğiz.Amaç işlem başarılı olduğunda bu nesneyi dönebilmek.
            {
                Data = data,
                SuccessMessage = successMessage
            };
        }

        public static ServiceResult<T> Error(string error)//Bu method ile işlem sırasında oluşan hata mesajını döneceğiz.Amaç hata oluştuğunda bu methodu kullanarak hata mesajını dönebilmek.
        {
            return new ServiceResult<T>
            {
                Errors = [error]
            };
        }

        public static ServiceResult<T> Error(List<string> errors)//Aamaç hata oluştuğunda birden fazla hata mesajını dönebilmek.Burada hata mesajlarını liste olarak döneceğiz.
        {
            return new ServiceResult<T>
            {
                Errors = errors
            };
        }
    }

    public class ServiceResult
    {
        public List<string>? Errors { get; set; }
        public string? SuccessMessage { get; set; }
        public bool IsFail => Errors is not null && Errors.Count > 0;

        public bool IsSuccess => !IsFail;
        public static ServiceResult Success(string? successMessage=null)
        {
            return new ServiceResult
            {
                SuccessMessage = successMessage
            };
        }
        public static ServiceResult Error(string error)
        {
            return new ServiceResult
            {
                Errors = [error]
            };
        }
        public static ServiceResult Error(List<string> errors)
        {
            return new ServiceResult
            {
                Errors = errors
            };
        }
    }
}
