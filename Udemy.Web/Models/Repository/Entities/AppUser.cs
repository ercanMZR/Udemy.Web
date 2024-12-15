using Microsoft.AspNetCore.Identity;

namespace Udemy.Web.Models.Repository.Entities
{
    public class AppUser:IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

    }
}
