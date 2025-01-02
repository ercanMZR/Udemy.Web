using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Udemy.Web.Models.Services.ViewModel.Course
{
    public record CreateCourseViewModel
    {
        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public IFormFile? PictureFile { get; set; }

        public string LearningGoal { get; set; }

        public decimal Price { get; set; }

        public int TotalHourTime { get; set; }

        public int CategoryId { get; set; }

        [ValidateNever]
        public SelectList CategoryList { get; set; }//Bu property ile kategorileri dropdownlistte göstermek için SelectList tipinde bir property oluşturuyoruz.
    }
}
