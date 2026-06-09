using Microsoft.EntityFrameworkCore;
using NewUserSite.Data;
using NewUserSite.Models;

namespace NewUserSite.Services
{
    public class ADOrganizationalUnitService
    {
        private IDbContextFactory<NewUserDbContext> dbContextFactory;

        public ADOrganizationalUnitService(IDbContextFactory<NewUserDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public void AddADOrganizationalUnitToDatabase(ADOrganizationalUnit adOrganizationalUnit)
        {
            using (NewUserDbContext context = dbContextFactory.CreateDbContext())
            {
                context.AdOrganizationalUnits.Add(adOrganizationalUnit);
                context.SaveChanges();
            }
        }
}
}
