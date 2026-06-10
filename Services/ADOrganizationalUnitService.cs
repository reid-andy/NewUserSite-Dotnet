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
                context.ADOrganizationalUnits.Add(adOrganizationalUnit);
                context.SaveChanges();
            }
        }

        public List<ADOrganizationalUnit> GetADOrganizationalUnitsFromDatabase()
        {
            using (NewUserDbContext context = dbContextFactory.CreateDbContext())
            {
                return context.ADOrganizationalUnits.ToList();
            }
        }

        public List<ADOrganizationalUnit> GetADOrganizationalUnitsForTemplateFromDatabase(int templateId)
        {
            using (NewUserDbContext context = dbContextFactory.CreateDbContext())
            {
                return context.NewUserTemplates
                    .Where(t => t.Id == templateId)
                    .SelectMany(t => t.ADOrganizationalUnits)
                    .ToList();
            }
        }
    }
}
