namespace Udemy.Web.Models.Repository.Entities
{
    public class Course
    {
        public string Title { get; set; } = default!;

        public string ShortDescription { get; set; }=default!;

        public string Description { get; set; }= default!;

        public string PictureUrl { get; set; }

        public string LearningGoal { get; set; } = default!;


        public int Hour { get; set; }



    }
}