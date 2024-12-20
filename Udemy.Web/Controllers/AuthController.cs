using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Udemy.Web.Models.Repository.Entities;
using Udemy.Web.Models.Services;
using Udemy.Web.Models.Services.ViewModel.Auth;

namespace Udemy.Web.Controllers
{
    public class AuthController(UserService userService,SignInManager<AppUser>signInManager) : BaseController
    {
        [AllowAnonymous]//Bu özellik, belirtilen aksiyonun kimlik doğrulaması gerektirmediğini belirtir. Yani, bu aksiyon herkes tarafından erişilebilir.
        public IActionResult SignIn()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var result = await userService.SignIn(model);
            SuccessOrFail(result);
            if (result.IsFail)
            {
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var result = await userService.SignUpAsync(model);
            SuccessOrFail(result);
            if (result.IsFail)
            {
                return View(model);
            }
            return RedirectToAction("SignIn", "Auth");
        }
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
