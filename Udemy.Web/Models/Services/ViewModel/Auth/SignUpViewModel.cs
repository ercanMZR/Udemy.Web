namespace Udemy.Web.Models.Services.ViewModel.Auth
{
    public class SignUpViewModel
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;

        public string ConfirmPassword { get; set; } = default!;//Özellikle, string gibi referans türleri için, default ifadesi null değerini döndürür. Ancak default! kullanarak, derleyiciye bu değişkenin asla null olmayacağını ve bu nedenle null referans hatalarının önüne geçileceğini belirtmiş olursunuz. Bu, kodun daha güvenli ve okunabilir olmasına yardımcı olur.



    }
}
