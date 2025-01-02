using Microsoft.EntityFrameworkCore;
using Udemy.Web.Models.Repository.Entities;

namespace Udemy.Web.Models.Repository.Courses
{
    public class CourseRepository(AppDbContext context) : GenericRepository<Course>(context), ICourseRepository
    {
        public async Task<List<Course>> GetAllCoursesByUserId(Guid userId)//Kullanıcının oluşturduğu kursları getirir.
        {
            return await _context.Courses.Include(x=>x.Category).Where(x=>x.CreatedBy == userId).OrderByDescending(x=>x.CreatedAt).ToListAsync();//Bunu yazdık çünkü Course tablosunda CategoryId var ama Category tablosunda CourseId yok. Bu yüzden Include ile Category tablosunu da çektik.CreatedBy ile userId eşleşen kursları getirir.Include ile Category tablosunu da çektik.orderbydescending ile CreatedAt'e göre sıraladık.
        }
        public async Task<List<Course>>GetAllCourses()//Tüm kursları getirir.
        {
            return await _context.Courses.Include(x => x.Category).OrderByDescending(x => x.CreatedAt).ToListAsync();//Include ile Category tablosunu da çektik.orderbydescending ile CreatedAt'e göre sıraladık.
        }

        public async Task<Course?> GetCourseById(Guid courseId)//Id'si verilen kursu getirir.
        {
            return await _context.Courses.Include(x => x.Category).Where(x => x.Id == courseId).FirstOrDefaultAsync();//Include ile Category tablosunu da çektik.
        }
    }
}
