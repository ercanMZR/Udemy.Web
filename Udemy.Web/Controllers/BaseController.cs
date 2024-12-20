using Microsoft.AspNetCore.Mvc;
using Udemy.Web.Models.Services;

namespace Udemy.Web.Controllers
{
    public class BaseController : Controller
    {
        public void Error(string message)
        {
            TempData["status"] = false;
            TempData["errorMessages"] = message;

        }

        private void Success(string? message)
        {
            TempData["status"] = true;
            TempData["successMessages"] ??= message;
        }

        public bool SuccessOrFail(ServiceResult result)
        {
            if (result.IsFail)
            {
                Error(result.Errors!.First());
            }
            else
            {
                Success(result.SuccessMessage);
            }
            return result.IsSuccess;


        }

        public bool SuccessOrFail<T>(ServiceResult<T> result)
        {
            if (result.IsFail)
            {
                Error(result.Errors!.First());
            }
            else
            {
                Success(result.SuccessMessage);
            }
            return result.IsSuccess;
        }

        public void LoadModelError(ServiceResult result) {
            if (result.IsFail)
            {
                foreach (var error in result.Errors!)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }
        }
    }
}
