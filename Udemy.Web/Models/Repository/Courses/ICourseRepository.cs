using Udemy.Web.Models.Repository.Entities;
using Udemy.Web.Models.Services.ViewModel;

namespace Udemy.Web.Models.Repository.Courses
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<List<Course>> GetAllCoursesByUserId(Guid userId);

        Task<List<Course>> GetAllCourses();
    }
}
