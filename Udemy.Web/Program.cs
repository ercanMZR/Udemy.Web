using Microsoft.EntityFrameworkCore;
using Udemy.Web.Models.Repository;
using Udemy.Web.Models.Repository.Courses;
using Udemy.Web.Models.Repository.Entities;
using Udemy.Web.Models.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));//Burada typeof metodu ile IGenericRepository ve GenericRepository s�n�flar�n� ekliyoruz.//typeof(IGenericRepository<>) ifadesi, IGenericRepository aray�z�n�n t�r�n� temsil ederken, typeof(GenericRepository<>) ifadesi de GenericRepository s�n�f�n�n t�r�n� temsil eder. Bu kullan�m, ba��ml�l�k enjeksiyonu (Dependency Injection) i�in gerekli olan t�rleri kaydetmek amac�yla yap�l�r.
builder.Services.AddScoped<ICourseRepository, CourseRepository>();//ICourseRepository ve CourseRepository s�n�flar�n� ekliyoruz.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<CourseServices>();//CourseServices s�n�f�n� ekliyoruz.

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.ConfigureApplicationCookie(opt =>
{
    var cookieBuilder = new CookieBuilder
    {
        Name = "UdemyAppCookie"
    };
    opt.LoginPath = new PathString("/Home/Signin");
    opt.LogoutPath = new PathString("/Member/Logout");
    opt.AccessDeniedPath = new PathString("Member/AccessDenied");
    opt.Cookie = cookieBuilder;
    opt.SlidingExpiration = true;
    opt.ExpireTimeSpan = System.TimeSpan.FromDays(60);
});



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
app.UseAuthentication();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
