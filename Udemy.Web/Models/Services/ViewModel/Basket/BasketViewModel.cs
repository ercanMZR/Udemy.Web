using System.Globalization;

namespace Udemy.Web.Models.Services.ViewModel.Basket
{
    public class BasketViewModel
    {
        public Guid Id { get; set; }

        public List<BasketItemViewModel>? BasketItemViewModels { get; set; }//Sepetteki kursları tutacak olan model.? işareti ile null olabileceğini belirtiyoruz.

        public string? TotalPrice => BasketItemViewModels?
     .Sum(x => x.CoursePrice)
     .ToString("C");

    }

}
