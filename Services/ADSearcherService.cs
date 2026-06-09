using Microsoft.EntityFrameworkCore;
using NewUserSite.Data;
using NewUserSite.Models;

namespace NewUserSite.Services
{
    public class ADSearcherService
    {
        private IDbContextFactory<NewUserDbContext> dbContextFactory;

        public ADSearcherService(IDbContextFactory<NewUserDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public void AddADSearcherToDatabase(ADSearcher adSearcher)
        {
            using (NewUserDbContext context = dbContextFactory.CreateDbContext())
            {
                context.ADSearchers.Add(adSearcher);
                context.SaveChanges();
            }
        }
    }
}
