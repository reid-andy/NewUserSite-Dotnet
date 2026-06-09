using Microsoft.EntityFrameworkCore;
using NewUserSite.Data;
using NewUserSite.Models;

namespace NewUserSite.Services
{
    public class NewUserTemplateService
    {
        private IDbContextFactory<NewUserDbContext> dbContextFactory;

        public NewUserTemplateService(IDbContextFactory<NewUserDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public void AddNewUserTemplateToDatabase(NewUserTemplate newUserTemplate)
        {
            using (NewUserDbContext context = dbContextFactory.CreateDbContext())
            {
                context.NewUserTemplates.Add(newUserTemplate);
                context.SaveChanges();
            }
        }
    }
}