using Microsoft.AspNetCore.SignalR;
using NewUserSite.Hubs;

namespace NewUserSite.Services
{
    public class RoleChangeNotificationService
    {
        private readonly IHubContext<RoleHub> _hubContext;

        public RoleChangeNotificationService(IHubContext<RoleHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task NotifyRoleChangedAsync()
        {
            await _hubContext.Clients.All.SendAsync("RolesUpdated");
        }
    }
}
