using Microsoft.AspNetCore.Components;
using NewUserSite.Services;

namespace NewUserSite.Components
{
    public class RoleListeningComponentBase : ComponentBase, IDisposable
    {
        [Inject] protected UserRoleService UserRoleService { get; set; } = null!;
        [Inject] protected RoleHubClientService RoleHubClientService { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            await UserRoleService.LoadRoles();
            RoleHubClientService.RolesUpdated += OnRolesUpdatedAsync;
        }

        protected virtual async Task OnRolesUpdatedAsync()
        {
            await UserRoleService.LoadRoles();
            StateHasChanged();
        }

        void IDisposable.Dispose()
        {
            RoleHubClientService.RolesUpdated -= OnRolesUpdatedAsync;
        }
    }
}
