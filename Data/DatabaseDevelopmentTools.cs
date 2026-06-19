using Microsoft.EntityFrameworkCore;

namespace NewUserSite.Data
{
    public class DatabaseDevelopmentTools
    {
        private IDbContextFactory<NewUserSite.Data.NewUserDbContext> dbContextFactory;
        public async Task RestartDatabase() {
            var context = dbContextFactory.CreateDbContext();
            Console.WriteLine("Dropping Database...");
            await context.Database.EnsureDeletedAsync();
            Console.WriteLine("Database Dropped. Recreating...");
            await context.Database.EnsureCreatedAsync();
            Console.WriteLine("Database Created. Seeding...");

        }
    }
}
