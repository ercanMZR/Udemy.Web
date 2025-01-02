namespace Udemy.Web.Models.Services.ViewModel.Basket
{
    public class BasketItemViewModel
    {
        public Guid CourseId { get; set; }
        public string? CoursePictureFileName { get; set; }
        public string CourseTitle { get; set; } // Guid yerine string olarak değiştirildi
        public decimal CoursePrice { get; set; }
    }
}
