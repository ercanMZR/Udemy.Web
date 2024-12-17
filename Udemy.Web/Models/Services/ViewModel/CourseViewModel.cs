namespace Udemy.Web.Models.Services.ViewModel
{
    public class CourseViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; } = default!; 

        public string EducatorName { get; set; } 
        public decimal Price { get; set; }

        public string PictureFileName { get; set; } = default!;

        public bool IsActive { get; set; }

        public int TotalHourTime { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public string CategoryName { get; set; } = default!;

    }
}
