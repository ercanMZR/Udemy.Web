namespace Udemy.Web.Models.Services.ViewModel.Auth
{
    public class SignInViewModel
    {
        public string Email { get; set; } = default!;//string.Empty ile boş bir string ifade oluşturuyoruz.
        public string Password { get; set; } = default!;

        public bool RememberMe { get; set; } = default!;
    }
}
