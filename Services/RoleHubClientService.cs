using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace NewUserSite.Services
{
    public class RoleHubClientService : IAsyncDisposable
    {
        private HubConnection? _hubConnection;
        private readonly NavigationManager _navigationManager;
        public event Func<Task> RolesUpdated;

        public RoleHubClientService(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public async Task ConnectAsync()
        {
            if (_hubConnection?.State == HubConnectionState.Connected)
                return;

            _hubConnection = new HubConnectionBuilder()
                .WithUrl(_navigationManager.ToAbsoluteUri("/rolehub"))
                .WithAutomaticReconnect()
                .Build();

            _hubConnection.On("RolesUpdated", async () =>
            {
                if (RolesUpdated is not null)
                    await RolesUpdated.Invoke();
            });

            await _hubConnection.StartAsync();
        }

        public async ValueTask DisposeAsync()
        {
            if (_hubConnection is not null)
            {
                await _hubConnection.DisposeAsync();
            }
        }
    }
}
