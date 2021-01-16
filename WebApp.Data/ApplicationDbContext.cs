using Microsoft.AspNet.Identity.EntityFramework;
using WebApp.Core.Entities;

namespace WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<WebApp.Core.Entities.Laptop> Laptops { get; set; }
    }
}