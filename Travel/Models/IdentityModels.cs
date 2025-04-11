using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Travel.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string UserType { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Regions> Regions { get; set; }
        public ICollection<offers> offers { get; set; }
        public ICollection<Post>Posts { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<ApplyForTrip> applyForTrips { get; set; }
        public DbSet<offers> offers { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Travel.Models.RoleViewModel> RoleViewModels { get; set; }

        public System.Data.Entity.DbSet<Travel.Models.ApplyForTripOffers> ApplyForTripOffers { get; set; }

        public System.Data.Entity.DbSet<Travel.Models.Companies> Companies { get; set; }

        public System.Data.Entity.DbSet<Travel.Models.Post> Posts { get; set; }

    }
}