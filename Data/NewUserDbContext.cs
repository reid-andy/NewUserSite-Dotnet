using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewUserSite.Models;

namespace NewUserSite.Data
{
    public class NewUserDbContext : DbContext, IDataProtectionKeyContext
    {
        public NewUserDbContext(DbContextOptions<NewUserDbContext> options) : base(options)
        {
        }

        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; } = null!;
        public DbSet<ADSearcher> ADSearchers { get; set; }
        public DbSet<NewUser> NewUsers { get; set; }
        public DbSet<ADOrganizationalUnit> ADOrganizationalUnits { get; set; }
        public DbSet<NewUserTemplate> NewUserTemplates { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Hardware> Hardware { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Domain> Domains { get; set; }
        public DbSet<ApplicationPreferences> ApplicationPreferences { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationPreferences>()
                .HasData(new ApplicationPreferences
                {
                    Id = 1,
                    OrganizationalUnit = "Department",
                    Template = "Job Title"
                });

            modelBuilder.Entity<ApplicationPreferences>()
                .Property(ap => ap.OrganizationalUnit)
                .HasDefaultValue("Department");

            modelBuilder.Entity<ApplicationPreferences>()
                .Property(ap => ap.Template)
                .HasDefaultValue("Job Title");

            modelBuilder.Entity<UserRole>()
                .HasData(new UserRole
                {
                    Id = 1,
                    Role = Role.Admin,
                    ADGroupName = "Domain Users"
                });
        }
    }
}
