using Microsoft.EntityFrameworkCore;
using Udemy.Web.Models.Repository;
using Udemy.Web.Models.Repository.Courses;
using Udemy.Web.Models.Repository.Entities;
using Udemy.Web.Models.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));//Burada typeof metodu ile IGenericRepository ve GenericRepository sýnýflarýný ekliyoruz.//typeof(IGenericRepository<>) ifadesi, IGenericRepository arayüzünün türünü temsil ederken, typeof(GenericRepository<>) ifadesi de GenericRepository sýnýfýnýn türünü temsil eder. Bu kullaným, baðýmlýlýk enjeksiyonu (Dependency Injection) için gerekli olan türleri kaydetmek amacýyla yapýlýr.
builder.Services.AddScoped<ICourseRepository, CourseRepository>();//ICourseRepository ve CourseRepository sýnýflarýný ekliyoruz.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<CourseServices>();//CourseServices sýnýfýný ekliyoruz.

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
