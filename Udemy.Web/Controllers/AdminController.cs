using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Udemy.Web.Models.Repository.Entities;

namespace Udemy.Web.Controllers
{
    public class AdminController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager) : Controller//AdminController sınıfı, uygulamadaki tüm kullanıcıları ve rolleri yönetmek için kullanılır. Bu sınıf, kullanıcıları ve rolleri oluşturmak, düzenlemek ve silmek için kullanılır.
    {
        public async Task<IActionResult> AddRoleToUser()
        {
            var newRole = new AppRole
            {
                Name = "Educator"

            };
            await roleManager.CreateAsync(newRole);
            var user = await userManager.FindByEmailAsync("yilmazsezer@gmail.com");

            await userManager.AddToRoleAsync(user, "Educator");

            return View();


        }
    }
}
     
