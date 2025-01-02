using System.Security.Claims;
using Udemy.Web.Caching;
using Udemy.Web.Models.Repository.Courses;
using Udemy.Web.Models.Services.ViewModel.Basket;
namespace Udemy.Web.Models.Services
{
    public class BasketService(
        ICacheService cacheService,
        IHttpContextAccessor httpContextAccessor,
        ICourseRepository courseRepository)
    {
        public async Task AddBasketItem(Guid courseId)
        {
            //httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            var course = await courseRepository.GetCourseById(courseId);
            var basketItemViewModel = new BasketItemViewModel()
            {
                CourseId = course.Id,
                CourseTitle = course.Title,
                CoursePictureFileName = course.PictureFileName,
                CoursePrice = course.Price
            };
            var cacheKey = GetBaketCacheKey();
            var hasBasketCache = await cacheService.Get<BasketViewModel>(cacheKey);
            hasBasketCache ??= new BasketViewModel();
            hasBasketCache.BasketItemViewModels ??= [];

            var hasBasketItem = hasBasketCache.BasketItemViewModels.Any(x => x.CourseId == courseId);
            if (hasBasketItem) return;
            hasBasketCache.BasketItemViewModels.Add(basketItemViewModel);
            await cacheService.Set(cacheKey, hasBasketCache);
        }
        public async Task RemoveBasketItem(Guid courseId)
        {
            var cacheKey = GetBaketCacheKey();
            var hasBasketCache = await cacheService.Get<BasketViewModel>(cacheKey);
            if (hasBasketCache is null) return;
            if (hasBasketCache.BasketItemViewModels is null) return;
            var hasBasketItem = hasBasketCache.BasketItemViewModels.FirstOrDefault(x => x.CourseId == courseId);
            if (hasBasketItem is null) return;
            hasBasketCache.BasketItemViewModels.Remove(hasBasketItem);
            await cacheService.Set(cacheKey, hasBasketCache);
        }
        public async Task<BasketViewModel> Get()
        {
            var cacheKey = GetBaketCacheKey();
            var hasBasketCache = await cacheService.Get<BasketViewModel>(cacheKey);
            return hasBasketCache ?? new BasketViewModel();
        }
        private string GetBaketCacheKey()
        {
            var userId = httpContextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cacheKey = $"basket:{userId}";
            return cacheKey;
        }
        public async Task<int> GetBasketCount()
        {
            var cacheKey = GetBaketCacheKey();
            var hasBasketCache = await cacheService.Get<BasketViewModel>(cacheKey);
            if (hasBasketCache is null) return 0;
            if (hasBasketCache.BasketItemViewModels is null) return 0;
            return hasBasketCache.BasketItemViewModels.Count;
        }
        public async Task RemoveBasketCache()
        {
            var cacheKey = GetBaketCacheKey();
            await cacheService.Remove(cacheKey);
        }
    }
}