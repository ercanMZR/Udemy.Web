using Microsoft.AspNetCore.Mvc;
using Udemy.Web.Models.Services;

namespace Udemy.Web.Controllers
{
    public class EducatorController : Controller//CourseServices sınıfından courseServices adında bir parametre alıyoruz..EducatorController sınıfının amacı eğitmenin kurslarını oluşturması ve görüntülemesidir.
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    

    public async Task<IActionResult> CreateCourse()
        {
            return View();
        }
    }
}
    