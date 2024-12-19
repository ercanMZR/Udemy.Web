using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using Udemy.Web.Models.Repository;
using Udemy.Web.Models.Repository.Courses;
using Udemy.Web.Models.Repository.Entities;
using Udemy.Web.Models.Services.ViewModel;

namespace Udemy.Web.Models.Services
{
    public class CourseServices(ICourseRepository courseRepository, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork,UserManager<AppUser>userManager)
    {
        public async Task<ServiceResult> CreateCourseAsync(CreateCourseViewModel model)//CreateCourseViewModel sınıfından model adında bir parametre alıyoruz.
        {
            var userId = httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;//Kullanıcının Id'sini alıyoruz.

            var newCourse = new Course
            {
                Title = model.Title,
                ShortDescription = model.ShortDescription,
                Description = model.Description,
                LearningGoal = model.LearningGoal,
                Price = model.Price,
                TotalHourTime = model.TotalHourTime,
                CategoryId = model.CategoryId,
                CreatedAt = DateTime.Now,
                CreatedBy = Guid.Parse(userId)//Kursu oluşturan kullanıcının Id'sini atıyoruz.
            };
            if (model.PictureFile is not null && model.PictureFile.Length > 0)//burada dosya yüklenmiş mi kontrolü yapıyoruz.
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(model.PictureFile.FileName)}";//dosya adını oluşturuyoruz.

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pictures", "courses", fileName);//dosyanın kaydedileceği yolu belirtiyoruz.
                using var stream = new FileStream(path, FileMode.Create);//FileStream sınıfı ile dosyayı oluşturuyoruz.
                await model.PictureFile.CopyToAsync(stream);//dosyayı oluşturduğumuz yere kopyalıyoruz.
                newCourse.PictureFileName = fileName;
            }
            await courseRepository.AddAsync(newCourse);
            await unitOfWork.CommitAsync();//CommitAsync metodu ile değişiklikleri kaydediyoruz.
            return ServiceResult.Success("Kurs başarıyla oluşturuldu.");//ServiceResult sınıfının Success metodu ile başarılı bir sonuç döndürüyoruz.
        }

        public async Task<ServiceResult<IEnumerable<CourseViewModel>>> GetAllCoursesByUserIdAsync()
        {
            var userId = httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var courses = await courseRepository.GetAllCoursesByUserId(Guid.Parse(userId));

            var courseViewModels = courses.Select(course => new CourseViewModel
            {
                
                Title = course.Title,
                ShortDescription = course.ShortDescription,
                PictureFileName= course.PictureFileName,
                Price = course.Price,
                TotalHourTime = course.TotalHourTime,
                CategoryName = course.Category.Name,
                CreatedAt = course.CreatedAt
            });

            return ServiceResult<IEnumerable<CourseViewModel>>.Success(courseViewModels, "Dersler başarıyla alındı.");
        }

        public async Task<ServiceResult<IEnumerable<CourseViewModel>>> GetAllCoursesAsync()
        {
            var courses = await courseRepository.GetAllCourses();

            var courseViewModelList = new List<CourseViewModel>();
            foreach(var course in courses)
            {
                var user = await userManager.FindByIdAsync(course.CreatedBy.ToString());
                var viewModel = new CourseViewModel
                {
                    Title = course.Title,
                    ShortDescription = course.ShortDescription,
                    PictureFileName = course.PictureFileName,
                    Price = course.Price,
                    TotalHourTime = course.TotalHourTime,
                    CreatedAt = course.CreatedAt,
                    EducatorName = user.GetFullName(),
                    CategoryName = course.Category.Name
                };

                courseViewModelList.Add(viewModel);
            }

            return ServiceResult<IEnumerable<CourseViewModel>>.Success(courseViewModelList, "Dersler başarıyla alındı.");

        }
    }
}
