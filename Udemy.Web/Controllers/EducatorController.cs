using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Udemy.Web.Models.Services;
using Udemy.Web.Models.Services.ViewModel.Course;

namespace Udemy.Web.Controllers
{
    [Authorize(Roles = "Educator")]//Bu sınıfın sadece eğitmen rolüne sahip kullanıcılar tarafından erişilebileceğini belirtmek için Authorize özniteliğini kullanıyoruz.
    public class EducatorController(CourseService courseService) : BaseController
    {
        public async Task<IActionResult> Index()
        {
            var result = await courseService.GetAllCoursesAsync();//Tüm kursları getirir.
            return View(result.Data!.ToList);//result.Data'nın null olmadığını kontrol ediyoruz ve listeye çeviriyoruz.
        }


        public async Task<IActionResult> CreateCourse()
        {
            return View(await courseService.LoadCreateCourseAsync());//CreateCourse sayfasını yükler.
        }


        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await courseService.LoadCreateCourseAsync(model);//CreateCourse sayfasını yükler.
                return View(model);
            }

            var result = await courseService.CreateCourseAsync(model);//Kurs oluşturur.
            SuccessOrFail(result);//Başarılı olup olmadığını kontrol eder.
            if (result.IsFail)
            {
                await courseService.LoadCreateCourseAsync(model);//CreateCourse sayfasını yükler.
                return View(model);
            }
            return RedirectToAction("Index","Educator");//Index sayfasına yönlendirir.

        }
    }
}

    