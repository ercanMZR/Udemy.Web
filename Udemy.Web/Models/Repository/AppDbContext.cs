using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Udemy.Web.Models.Repository.Entities;

namespace Udemy.Web.Models.Repository
{
    public class AppDbContext(DbContextOptions<AppDbContext>options ) : IdentityDbContext<AppUser, AppRole, Guid>(options)
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Basket> Baskets { get; set; }

        public DbSet<BasketItem> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)//Bu metod ile entitylerin mappinglerini yapabiliriz.
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//Bu kod ile tüm entitylerin mappinglerini tek bir yerden yapmış oluyoruz.
            base.OnModelCreating(builder);//IdentityDbContext sınıfının OnModelCreating metodunu override ediyoruz.
        }

    }
}
