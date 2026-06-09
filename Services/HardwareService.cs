using Microsoft.EntityFrameworkCore;
using NewUserSite.Data;
using NewUserSite.Models;

namespace NewUserSite.Services
{
    public class HardwareService
    {
        private IDbContextFactory<NewUserDbContext> dbContextFactory;

        public HardwareService(IDbContextFactory<NewUserDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public void AddHardwareToDatabase(Hardware hardware)
        {
            using (NewUserDbContext context = dbContextFactory.CreateDbContext())
            {
                context.Hardware.Add(hardware);
                context.SaveChanges();
            }
        }
    }
}
