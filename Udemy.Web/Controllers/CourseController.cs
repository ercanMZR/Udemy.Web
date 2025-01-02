using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Udemy.Web.Models.Services;

namespace Udemy.Web.Controllers
{
    public class CourseController (CourseService CourseService) : Controller
    {
        public async Task<IActionResult> Detail(Guid id)
        {
           var result = await CourseService.GetCourseById(id);

            if (result.IsFail)
            {

            }
            return View(result.Data);
        }
       
    }
}
