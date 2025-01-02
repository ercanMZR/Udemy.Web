using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Udemy.Web.Models;
using Udemy.Web.Models.Services;

namespace Udemy.Web.Controllers
{
    public class HomeController(CourseService courseService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await courseService.GetAllCoursesAsync();
            return View(response.Data);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}