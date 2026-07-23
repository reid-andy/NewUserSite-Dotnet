using NewUserSite.Models;
using NewUserSite.Data;
using Microsoft.EntityFrameworkCore;

namespace NewUserSite.Services
{
    public class UserRoleService
    {
        private readonly IDbContextFactory<NewUserDbContext> _dbContextFactory;
        public UserRoleService(IDbContextFactory<NewUserDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public List<string?>? AdminRoles { get; set; }
        public List<string?>? UserRoles { get; set; }

        public async Task LoadRoles()
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            var roles = await dbContext.UserRoles.ToListAsync();

            AdminRoles = roles
                .Where(r => r.Role == Role.Admin)
                .Select(r => r.ADGroupName)
                .ToList();

            UserRoles = roles
                .Where(r => r.Role == Role.User)
                .Select(r => r.ADGroupName)
                .ToList();
        }
    }
}
