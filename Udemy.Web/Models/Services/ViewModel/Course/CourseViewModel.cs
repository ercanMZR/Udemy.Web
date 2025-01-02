namespace Udemy.Web.Models.Services.ViewModel.Course
{
    public class CourseViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; } = default!;

        public string? Description { get; set; }

        public string EducatorName { get; set; }
        public string Price { get; set; }

        public string? PictureFileName { get; set; } = default!;

        public bool IsActive { get; set; }

        public int TotalHourTime { get; set; }

        public string CreatedAt { get; set; } = default!;

        public string? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public string CategoryName { get; set; } = default!;

        public string GetUpdatedAt()
        {
            return string.IsNullOrEmpty(UpdatedAt) ? "-" : UpdatedAt;//Eğer UpdatedAt boş ise - döndür.
        }

    }
}
