namespace Udemy.Web.Models.Repository.Entities
{
    public class Course : BaseEntity<Guid>, IAuditEntity
    {
        public string Title { get; set; } = default!;
        public string ShortDescription { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string PictureFileName { get; set; }
        public string LearningGoal { get; set; } = default!;
        
        public bool IsActive { get; set; }

        public decimal Price { get; set; }

        public int TotalHourTime { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid CreatedBy { get; set; }

        public bool IsDeleted { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; } = default!;
    }
}