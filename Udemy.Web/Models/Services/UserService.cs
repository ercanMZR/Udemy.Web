using Microsoft.AspNetCore.Identity;
using Udemy.Web.Models.Repository.Entities;
using Udemy.Web.Models.Services.ViewModel.Auth;

namespace Udemy.Web.Models.Services
{
    public class UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        public async Task<ServiceResult> SignUpAsync(SignUpViewModel model)
        {
            var randomUserName = $"{model.FirstName}_{model.LastName}_{new Random().Next(1, 1000)}";

            var newUser = new AppUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,

            };

            var result = await userManager.CreateAsync(newUser, model.Password);// userManager.CreateAsync(newUser, model.Password) metodu çağrılarak yeni bir kullanıcı oluşturulmak isteniyor. Bu metod, newUser nesnesini ve kullanıcının şifresini alarak, belirtilen bilgileri kullanarak veritabanında yeni bir kullanıcı kaydı oluşturur.

            if (!result.Succeeded)//Eğer işlem başarısız olursa, result.Succeeded özelliği false değerini döndürecektir. Bu durumda, result.Errors koleksiyonundaki hatalar ServiceResult.Error metodu ile döndürülür.
            {
                var errors = result.Errors.Select(x => x.Description).ToList();//result.Errors koleksiyonundaki hataların Description özelliği kullanılarak hata mesajları alınır ve bir liste olarak döndürülür.
                return ServiceResult.Error(errors);
            }

            return ServiceResult.Success("User created successfully");
        }

        public async Task<ServiceResult> SignIn(SignInViewModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);//Kullanıcının e-posta adresine göre veritabanında arama yapılır ve kullanıcı bulunur.
            if (user is null)//Eğer kullanıcı bulunamazsa, ServiceResult.Error metodu ile hata mesajı döndürülür.
            {
                return ServiceResult.Error("Email or Password is wrong");
            }

            var passwordCheck = await userManager.CheckPasswordAsync(user, model.Password);//Kullanıcının şifresi kontrol edilir. Eğer şifre doğru değilse, ServiceResult.Error metodu ile hata mesajı döndürülür.
            if (!passwordCheck)
            {
                return ServiceResult.Error("Email or Password is wrong");
            }

            await signInManager.SignInAsync(user, model.RememberMe);//Kullanıcı giriş yaptıktan sonra, SignInAsync metodu ile kullanıcı oturum açar.

            return ServiceResult.Success("User signed in successfully");
        }
    }
}
