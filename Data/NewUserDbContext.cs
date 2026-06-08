using Microsoft.EntityFrameworkCore;
using NewUserSite.Models;

namespace NewUserSite.Data
{
    public class NewUserDbContext : DbContext
    {
        public NewUserDbContext(DbContextOptions<NewUserDbContext> options) : base(options)
        {
        }

        public DbSet<ADSearcher> AdSearchers { get; set; }
        public DbSet<NewUser> NewUsers { get; set; }
    }
}
