using Microsoft.EntityFrameworkCore;
using NewUserSite.Models;

namespace NewUserSite.Data
{
    public class NewUserDbContext : DbContext
    {
        public NewUserDbContext(DbContextOptions<NewUserDbContext> options) : base(options)
        {
        }

        public DbSet<ADSearcher> ADSearchers { get; set; }
        public DbSet<NewUser> NewUsers { get; set; }
        public DbSet<ADOrganizationalUnit> ADOrganizationalUnits { get; set; }
        public DbSet<NewUserTemplate> NewUserTemplates { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Hardware> Hardware { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Domain> Domains { get; set; }

    }
}
