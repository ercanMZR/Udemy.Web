using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Udemy.Web.Models.Services;

namespace Udemy.Web.Controllers
{
    [Authorize]
    public class BasketController(BasketService basketService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await basketService.Get());//Sepeti getir.
        }

        public async Task<IActionResult> AddBasketItem(Guid courseId)//Sepete ürün ekle.
        {
            await basketService.AddBasketItem(courseId);//AddBasketItem metodunu çağır.courseId parametresini gönder.
            return RedirectToAction("Index","Baskets");
        }

        public async Task<IActionResult>RemoveBasketItem(Guid courseId)
        {
            await basketService.RemoveBasketItem(courseId);//Sepetten ürünü sil.
            return RedirectToAction("Index", "Baskets");//Sepete git.
        }
    }
}
